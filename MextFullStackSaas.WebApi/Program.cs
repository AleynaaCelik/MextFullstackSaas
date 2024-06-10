using MextFullstackSaaS.WebApi.Filters;
using MextFullStackSaas.Application;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure;
using MextFullStackSaas.WebApi;

using MextFullStackSaas.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Serilog; // Doðru namespace'i ekleyin

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        path: "C:\\Users\\DELL\\Desktop\\Logs\\log.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting web application");//Loglamanýn baþladýðýný 

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog(); // <-- Add this line Serilog

    // Add services to the container.

    builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<GlobalExceptionFilter>();
    });
    //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    //builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();

    builder.Services.AddApplication();

    builder.Services.AddInfrastructure(builder.Configuration); // IConfiguration nesnesini geçirin

    builder.Services.AddWebServices(builder.Configuration);

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
    builder.Services.AddSingleton<IRoothPathService>(new RootPathManager(builder.Environment.WebRootPath));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseStaticFiles();

    var requestLocalizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
    app.UseRequestLocalization(requestLocalizationOptions.Value);

    app.UseHttpsRedirection();

    app.UseAuthentication(); //Servislere kaydederken oluþturduðum ayarlara bakacak

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
//Finally try da olsa catch olsa hepsinin sonunda çalýþýr 