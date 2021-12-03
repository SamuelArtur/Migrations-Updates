using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository.Interfaces
{
    public class ActivateCardRepositoryFactory : Interfaces.IActivateCardRepositoryFactory
    {
        private IServiceProvider _provider;

        public ActivateCardRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IActivateCardRepository Create() => _provider.GetService<IActivateCardRepository>();
    }
}