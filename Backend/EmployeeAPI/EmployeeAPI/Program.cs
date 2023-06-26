using EmployeeAPI.Context;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagementAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("UserCon")));
builder.Services.AddScoped<IRepo<int, User>, UserRepo>();
builder.Services.AddScoped<IRepo<int, Employee>, EmployeeRepo>();
builder.Services.AddScoped<IManageUser ,ManageUserService>();
builder.Services.AddScoped<IGeneratePassword,GeneratePasswordService>();
builder.Services.AddScoped<IListEmployee, ListEmployees>();
builder.Services.AddScoped<ITokenGenerate, TokenGenerateService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
