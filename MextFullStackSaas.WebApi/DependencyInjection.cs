using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.WebApi.Services;
using Microsoft.OpenApi.Models;

namespace MextFullStackSaas.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services,IConfiguration configuration) {

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "v1",
                    new OpenApiInfo()
                    {
                        Title = "MextFullStackSaaS Web API",
                        Version = "1",
                        Description = "Through this API you can access MextFullStackSaaS App's details",
                        Contact = new OpenApiContact()
                        {
                            Email = "alper.tunga@yazilim.academy",
                            Name = "Alper Tunga",
                            Url = new Uri("https://yazilim.academy/")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "© 2024 Yazılım Academy Tüm Hakları Saklıdır",
                            Url = new Uri("https://yazilim.academy/")
                        }
                    });

                setupAction.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
