using FlightManagementSystem.Application;
using FlightManagementSystem.Persistence;
using FlightManagementSystem.Presentation.Handlers;
using FlightManagementSystem.Presentation.Middleware;
using FlightManagementSystem.Presentation.Modules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Mock";
    options.DefaultChallengeScheme = "Mock";
}).AddMockAuthentication();

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightsDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});

builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.AddFlightsEndpoints();
app.Run();

