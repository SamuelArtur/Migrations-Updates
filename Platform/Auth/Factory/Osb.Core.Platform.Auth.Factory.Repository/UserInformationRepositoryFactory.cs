using System;
using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Factory.Repository
{
    public class UserInformationRepositoryFactory : Interfaces.IUserInformationRepositoryFactory
    {
        private IServiceProvider _provider;

        public UserInformationRepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }
        public IUserInformationRepository Create()
        {
           return _provider.GetService<IUserInformationRepository>();
        }
    }
}