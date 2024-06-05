using FluentValidation;
using MediatR;
using MextFullStackSaas.Application.Common.Behaviours;
using MextFullStackSaas.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace MextFullStackSaas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());


                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

                //<,> buradaki virgül tip hepsi olabilir demek
            });

            

            return services;
        }

    }
}
