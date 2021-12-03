using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Api.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTransientOutputFactories(this IServiceCollection services)
        {
            OutputServiceCollection.AddTransientOutputFactories(services);
        }
    }
}