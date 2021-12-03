using Microsoft.Extensions.DependencyInjection;

namespace Osb.Core.Platform.Business.Infrastructure.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddScopedBusinessFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddScopedFactories(services);
            BankServiceCollection.AddScopedFactories(services);
            InternalTransferServiceCollection.AddScopedFactories(services);
            OperationServiceCollection.AddScopedFactories(services);
            OperationTagServiceCollection.AddScopedFactories(services);
            SubAccountServiceCollection.AddScopedFactories(services);
            BoletoPaymentServiceCollection.AddScopedFactories(services);
            MoneyTransferServiceCollection.AddScopedFactories(services);
            BankingDataServiceCollection.AddScopedFactories(services);
            AccountLogServiceCollection.AddScopedFactories(services);
            CompanyServiceCollection.AddScopedFactories(services);
            HashCodeServiceCollection.AddScopedFactories(services);
            FavoredServiceCollection.AddScopedFactories(services);
            TagServiceCollection.AddScopedFactories(services);
            CardServiceCollection.AddScopedFactories(services);
        }

        public static void AddSingletonBusinessFactories(this IServiceCollection services)
        {
            AccountServiceCollection.AddSingletonFactories(services);
            BankServiceCollection.AddSingletonFactories(services);
            InternalTransferServiceCollection.AddSingletonFactories(services);
            OperationServiceCollection.AddSingletonFactories(services);
            OperationTagServiceCollection.AddSingletonFactories(services);
            SubAccountServiceCollection.AddSingletonFactories(services);
            BoletoPaymentServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            BankingDataServiceCollection.AddSingletonFactories(services);
            AccountLogServiceCollection.AddSingletonFactories(services);
            CompanyServiceCollection.AddSingletonFactories(services);
            MoneyTransferServiceCollection.AddSingletonFactories(services);
            HashCodeServiceCollection.AddSingletonFactories(services);
            FavoredServiceCollection.AddSingletonFactories(services);
            TagServiceCollection.AddSingletonFactories(services);
            CardServiceCollection.AddSingletonFactories(services);
        }
    }
}