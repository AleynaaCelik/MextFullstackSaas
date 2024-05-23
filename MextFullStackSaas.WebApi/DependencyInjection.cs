using MextFullStackSaas.Application.Common.Interfaces;
using MextFullStackSaas.WebApi.Services;

namespace MextFullStackSaas.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services,IConfiguration configuration) {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
