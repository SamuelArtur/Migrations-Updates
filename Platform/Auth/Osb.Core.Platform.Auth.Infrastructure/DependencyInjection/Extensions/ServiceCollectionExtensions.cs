using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedAuthFactories(this IServiceCollection services) {
            AuthServiceCollection.AddScopedFactories(services);
            AuthorizationTokenServiceCollection.AddScopedFactories(services);
            UserServiceCollection.AddScopedFactories(services);
            UserAccountServiceCollection.AddScopedFactories(services);
        }

        public static void AddSingletonAuthFactories(this IServiceCollection services) {
            AuthServiceCollection.AddSingletonFactories(services);
            AuthorizationTokenServiceCollection.AddSingletonFactories(services);
            UserServiceCollection.AddSingletonFactories(services);
            UserAccountServiceCollection.AddSingletonFactories(services);
        }
    }
}