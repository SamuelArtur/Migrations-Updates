using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class SubAccountRepositoryFactory : Interfaces.ISubAccountRepositoryFactory
    {
        private IServiceProvider _provider;

        public SubAccountRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ISubAccountRepository Create() => _provider.GetService<ISubAccountRepository>();
    }
}