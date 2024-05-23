using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure;
using MextFullStackSaas.WebApi;
using MextFullStackSaas.WebApi.Services;
using Microsoft.Extensions.DependencyInjection; // Doðru namespace'i ekleyin

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddInfrastructure(builder.Configuration); // IConfiguration nesnesini geçirin

builder.Services.AddWebServices(builder.Configuration);

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
