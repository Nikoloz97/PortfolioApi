using Microsoft.EntityFrameworkCore;
using PortfolioApi.DbContexts;
using PortfolioApi.Services.Forum;
using PortfolioApi.Services.User;

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

builder.Services.AddScoped<IForumRepository, ForumRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("corsapp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
