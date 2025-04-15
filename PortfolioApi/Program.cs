using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Exceptions;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.DataAccess.User;
using PortfolioApi.DataAccess.GeoGame;
using PortfolioApi.Services.User;
using PortfolioApi.Services.Email;
using PortfolioApi.Services.Authentication;
using PortfolioApi.Services.Forum;
using PortfolioApi.Services.GeoGame;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using PortfolioApi.Entities.User;
using PortfolioApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["auth_token"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddDbContext<UserContext>(options =>
      options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
      sqlServerOptionsAction: sqlOptions =>
      {
          sqlOptions.EnableRetryOnFailure(
              maxRetryCount: 5,
              maxRetryDelay: TimeSpan.FromSeconds(15),
              errorNumbersToAdd: null
          );
      }
      ));

/* Repositories */
builder.Services.AddScoped<IForumRepository, ForumRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGeoGameRepository, GeoGameRepository>();

/* Services */
builder.Services.AddScoped<IForumProfileService, ForumProfileService>();
builder.Services.AddScoped<IGeoGameService, GeoGameService>();
builder.Services.AddScoped<IUserService, UserService>();

// Sendgrid
builder.Services.AddSingleton<IEmailService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new EmailService(configuration);
});

// AzureStorage
builder.Services.AddScoped<IAzureStorageService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration["AzureStorageConnectionString"];
    var containerName = configuration["AzureStorage:ProfileImagesContainer"];
    return new AzureStorageService(connectionString, containerName);
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options => options.AddPolicy("corsapp", policy =>
{
    policy
        .WithOrigins("http://localhost:3000", "https://nicksportfolioreact.azurewebsites.net")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

builder.Services.AddSingleton(builder.Configuration);

/* Misc */
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Enforce HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 443;
});

// Add HSTS for production
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHsts(options =>
    {
        options.Preload = true;
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromDays(365);
    });
}

var app = builder.Build();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/* Middleware */
app.UseMiddleware<ExceptionMiddleware>();

if (!app.Environment.IsDevelopment())
{
    // Enforced HTTPS
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
