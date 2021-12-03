using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Business.Repository.Interfaces;

namespace Osb.Core.Platform.Business.Factory.Repository
{
    public class InactivateCardRepositoryFactory : Interfaces.IInactivateCardRepositoryFactory
    {
        private IServiceProvider _provider;

        public InactivateCardRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IInactivateCardRepository Create() => _provider.GetService<IInactivateCardRepository>();
    }
}