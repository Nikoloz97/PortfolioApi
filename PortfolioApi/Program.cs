using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PortfolioApi.DbContexts;
using PortfolioApi.Exceptions;
using PortfolioApi.DataAccess.Forum;
using PortfolioApi.DataAccess.User;
using PortfolioApi.DataAccess.GeoGame;
using PortfolioApi.Services.User;
using PortfolioApi.Services.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ForumContext>(
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:ForumDBConnectionString"]));

builder.Services.AddDbContext<UserContext>(
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:UserDBConnectionString"]));

builder.Services.AddDbContext<GeoGameContext>(
    dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:GeoGameDBConnectionString"]));

builder.Services.AddScoped<IForumRepository, ForumRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGeoGameRepository, GeoGameRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEmailService, EmailService>();

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

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";
        
        // TODO: Abstract this code into exception classes
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is UsernameNotFoundException)
        {
            var errorResponse = new
            {
                error = new
                {
                    message = "The username entered does not exist. Please try again"
                }
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
        else if (exception is PasswordNotFoundException)
        {
            var errorResponse = new
            {
                error = new
                {
                    message = "The password for username entered does not exist. Please try again"
                }
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }

    });
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
