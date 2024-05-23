using MextFullstackSaaS.WebApi.Filters;
using MextFullStackSaas.Application;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure;
using MextFullStackSaas.WebApi;

using MextFullStackSaas.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection; // Doðru namespace'i ekleyin

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<GlobalExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration); // IConfiguration nesnesini geçirin

builder.Services.AddWebServices(builder.Configuration);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
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
