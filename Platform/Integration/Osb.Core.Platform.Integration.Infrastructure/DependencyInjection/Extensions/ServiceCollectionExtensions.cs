using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Integration.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedIntegrationFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddScopedFactories(services);
            BankServiceCollection.AddScopedFactories(services);
            CompanyAuthenticationServiceCollection.AddScopedFactories(services);
            InternalTransferServiceCollection.AddScopedFactories(services);
            MoneyTransferServiceCollection.AddScopedFactories(services);
            BoletoPaymentServiceCollection.AddScopedFactories(services);
            NotificationServiceCollection.AddScopedFactories(services);
            HashCodeServiceCollection.AddScopedFactories(services);
            TagServiceCollection.AddScopedFactories(services);
            CardServiceCollection.AddScopedFactories(services);
        }

        public static void AddSingletonIntegrationFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddSingletonFactories(services);
            BankServiceCollection.AddSingletonFactories(services);
            CompanyAuthenticationServiceCollection.AddSingletonFactories(services);
            InternalTransferServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            BoletoPaymentServiceCollection.AddSingletonFactories(services);
            NotificationServiceCollection.AddSingletonFactories(services);
            HashCodeServiceCollection.AddSingletonFactories(services);
            TagServiceCollection.AddSingletonFactories(services);
            CardServiceCollection.AddSingletonFactories(services);
        }
    }
}