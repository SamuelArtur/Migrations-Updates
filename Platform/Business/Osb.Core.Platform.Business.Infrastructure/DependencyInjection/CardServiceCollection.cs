using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Factory.Service;
using Osb.Core.Platform.Business.Factory.Service.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service;
using Osb.Core.Platform.Business.Service.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class CardServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardServiceFactory, CardServiceFactory>();
            services.AddScoped<IActivateCardRepository, ActivateCardRepository>();
            services.AddScoped<IActivateCardRepositoryFactory, ActivateCardRepositoryFactory>();
            services.AddScoped<IInactivateCardRepositoryFactory, InactivateCardRepositoryFactory>();
            services.AddScoped<IInactivateCardRepository, InactivateCardRepository>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ICardServiceFactory, CardServiceFactory>();
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<IActivateCardRepositoryFactory, ActivateCardRepositoryFactory>();
            services.AddSingleton<IActivateCardRepository, ActivateCardRepository>();
            services.AddSingleton<IInactivateCardRepositoryFactory, InactivateCardRepositoryFactory>();
            services.AddSingleton<IInactivateCardRepository, InactivateCardRepository>();
        }
    }
}