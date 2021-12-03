using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;

namespace Osb.Core.Platform.Integration.Factory.Service
{
    public class CardServiceFactory : ICardServiceFactory
    {
        private IServiceProvider _provider;

        public CardServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public ICardService Create()
        {
            return _provider.GetService<ICardService>();
        }

    }
}