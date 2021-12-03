using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Service
{
    public class UserInformationServiceFactory : Interfaces.IUserInformationServiceFactory
    {
        private IServiceProvider _provider;

        public UserInformationServiceFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IUserInformationService Create() => _provider.GetService<IUserInformationService>();
    }
}