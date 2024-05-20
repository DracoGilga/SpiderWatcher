using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presenters.DependencyContainers;
using RepositoryEFCore.DependencyContainers;
using UseCases.DependencyContainers;
using RepositoryEmail;

namespace IoC.DependencyContainers
{
    public static class User
    {
        public static IServiceCollection AddSpiderWatcherUserDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configurar dependencias para el usuario
            services.AddUserRepositories(configuration);
            services.AddUserServices();
            services.AddUserPresenters();

            // Configurar dependencias para el envío de correo electrónico
           services.AddEmailRepositories(configuration);

            return services;
        }
    }
}