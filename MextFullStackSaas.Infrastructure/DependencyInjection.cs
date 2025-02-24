﻿using MextFullstackSaas.Domain.Identity;
using MextFullstackSaas.Domain.Settings;
using MextFullstackSaaS.Infrastructure.Services;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure.Persistence.Contexts;
using MextFullStackSaas.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using Resend;

namespace MextFullStackSaas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>(
                container => container.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.Configure<JwtSettings>(JwtSettings=>configuration.GetSection("JwtSettings").Bind(JwtSettings));
            services.Configure<GoogleSettings>(googleSettings=>configuration.GetSection("GoogleSettings").Bind(googleSettings));
            services.Configure<IyzicoSettings>(iyzicosettings => configuration.GetSection("IyzicoSettings").Bind(iyzicosettings));
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;


                options.User.RequireUniqueEmail = true;

                //Set Email Validition 

            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            //Send the token lifespan to three hours for the email confirmation token
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(3);
                
            });

            //Dependency Inversion
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();
            services.AddScoped<IObjectStorageService, GoogleObjectStorageManager>();
            services.AddScoped<IPaymentService, IyzicoPaymentManager>();

            //OpenAI
            services.AddOpenAIService(settings => settings.ApiKey = configuration.GetSection("OpenAIApiKey").Value!);

            services.AddScoped<IOpenAIService, OpenAIManager>();

            //Resend
            services.AddOptions();
           services.AddHttpClient<ResendClient>();
            services.Configure<ResendClientOptions>(o =>
            {
                o.ApiToken = configuration.GetSection("ReSendApiKey").Value!;
            });
            services.AddTransient<IResend, ResendClient>();

            return services;
        }
    }
}
