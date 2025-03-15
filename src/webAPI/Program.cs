using Microsoft.EntityFrameworkCore;
using Products.Application;
using Products.Domain.Entities;
using Products.Infrastructure;
using Products.Presentation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                Products.Infrastructure.AssemblyReference.Assembly,
                Products.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(Products.Application.AssemblyReference.Assembly);



var app = builder.Build();

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
