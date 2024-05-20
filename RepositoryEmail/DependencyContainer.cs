using Azure.Communication.Email;
using DTOs;
using Entities.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryEmail.Repositories;

namespace RepositoryEmail
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddEmailRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Registrar la configuración de EmailSettings
            var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();

            if (emailSettings == null || string.IsNullOrWhiteSpace(emailSettings.ConnectionString))
            {
                throw new InvalidOperationException("The EmailSettings configuration is not configured properly.");
            }

            // Configurar EmailClient
            services.AddSingleton(provider =>
            {
                try
                {
                    return new EmailClient(emailSettings.ConnectionString);
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    throw new InvalidOperationException("Failed to create EmailClient.", ex);
                }
            });

            // Registrar EmailSettings para su uso en otras partes de la aplicación
            services.AddSingleton(emailSettings);

            // Configurar ISentEmail
            services.AddTransient<ISentEmail, SentEmailRepository>();

            return services;
        }
    }
}