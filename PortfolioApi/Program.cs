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

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options =>
      options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
      sqlServerOptionsAction: sqlOptions =>
      {
          sqlOptions.EnableRetryOnFailure(
              maxRetryCount: 5, 
              maxRetryDelay: TimeSpan.FromSeconds(30), 
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

builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IAuthService, AuthService>();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSingleton(builder.Configuration);

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



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
