using MextFullstackSaas.Domain.Identity;
using MextFullstackSaas.Domain.Settings;
using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.Infrastructure.Persistence.Contexts;
using MextFullStackSaas.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;


                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            //Dependency Inversion
            services.AddScoped<IJwtService, JwtManager>();
            services.AddScoped<IIdentityService, IdentityManager>();
            services.AddScoped<IEmailService, ResendEmailManager>();

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
