using Microsoft.EntityFrameworkCore;

using SecurePass.Applicatio.Services;
using SecurePass.Application.Contracts;
using SecurePass.Application.Services;
using SecurePass.Domain.Entities;
using SecurePass.Infraestructure.Data;
using SecurePass.Infraestructure.Repositories;
using SecurePass.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SecurePassApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllers();


// Add services to the container.
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<IDigitalSecurityTipCategoryService, DigitalSecurityTipCategoryService>();
builder.Services.AddScoped<IDigitalSecurityTipService, DigitalSecurityTipService>();
builder.Services.AddScoped<IPasswordGenerationService, PasswordGenerationService>();
builder.Services.AddScoped<IPasswordStrengthEvaluationService, PasswordStrengthEvaluationService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add repositories to the container.

builder.Services.AddScoped<IDigitalSecurityTipCategoryRepository, DigitalSecurityTipCategoryRepository>();
builder.Services.AddScoped<IDigitalSecurityTipRepository, DigitalSecurityTipRepository>();
builder.Services.AddScoped<IPasswordGenerationRepository, PasswordGenerationRepository>();
builder.Services.AddScoped<IPasswordStrengthEvaluationRepository, PasswordStrengthEvaluationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Adding cores

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Using cores
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
