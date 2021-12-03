using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Factory.Service;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection
{
    internal class CardServiceColletion
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardServiceFactory, CardServiceFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<ICardServiceFactory, CardServiceFactory>();
        }
    }
}