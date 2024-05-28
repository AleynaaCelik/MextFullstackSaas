using MextFullstackSaaS.WebApi.Filters;
using MextFullStackSaas.Application;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure;
using MextFullStackSaas.WebApi;

using MextFullStackSaas.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog; // Do�ru namespace'i ekleyin

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("Starting web application");//Loglaman�n ba�lad���n� 

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog(); // <-- Add this line Serilog

    // Add services to the container.

    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication();

    builder.Services.AddInfrastructure(builder.Configuration); // IConfiguration nesnesini ge�irin

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
}
catch (Exception e)
{
   
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();//temizle 
}
//Finally try da olsa catch olsa hepsinin sonunda �al���r 