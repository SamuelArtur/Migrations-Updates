using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Factory.Repository;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection
{
    internal class SubAccountServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<ISubAccountRepository, SubAccountRepository>();
            services.AddScoped<ISubAccountRepositoryFactory, SubAccountRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<ISubAccountRepository, SubAccountRepository>();
            services.AddSingleton<ISubAccountRepositoryFactory, SubAccountRepositoryFactory>();
        }
    }
}