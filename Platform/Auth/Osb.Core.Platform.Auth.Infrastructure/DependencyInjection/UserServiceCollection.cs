using Microsoft.Extensions.DependencyInjection;
using Osb.Core.Platform.Auth.Service;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Repository;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Service;
using Osb.Core.Platform.Auth.Factory.Service.Interfaces;

namespace Osb.Core.Platform.Auth.Infrastructure.DependencyInjection
{
    internal class UserServiceCollection
    {
        public static void AddScopedFactories(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserServiceFactory, UserServiceFactory>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRepositoryFactory, UserRepositoryFactory>();
            services.AddScoped<IUserInformationService, UserInformationService>();
            services.AddScoped<IUserInformationServiceFactory, UserInformationServiceFactory>();
            services.AddScoped<IUserInformationRepository, UserInformationRepository>();
            services.AddScoped<IUserInformationRepositoryFactory, UserInformationRepositoryFactory>();
        }

        public static void AddSingletonFactories(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserServiceFactory, UserServiceFactory>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRepositoryFactory, UserRepositoryFactory>();
            services.AddSingleton<IUserInformationService, UserInformationService>();
            services.AddSingleton<IUserInformationServiceFactory, UserInformationServiceFactory>();
            services.AddSingleton<IUserInformationRepository, UserInformationRepository>();
            services.AddSingleton<IUserInformationRepositoryFactory, UserInformationRepositoryFactory>();

        }
    }
}