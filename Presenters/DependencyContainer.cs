using Microsoft.Extensions.DependencyInjection;
using Presenters.User;
using UseCasesPort.UserPort.Outputs;

namespace Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateUserOutputPort,
                CreateUserPresenter>();

            services.AddScoped<IDeleteUserOutputPort, 
                DeleteUserPresenter>();
            
            services.AddScoped<ILoginUserOutputPort,
                LoginUserPresenter>();
            
            services.AddScoped<IReadAllUsersOutputPort,
                ReadAllUsersPresenter>();
            
            services.AddScoped<IReadUserOutputPort,
                ReadUserPresenter>();
            
            services.AddScoped<IUpdatePasswordUserOutputPort,
                UpdatePasswordUserPresenter>();
            
            services.AddScoped<IUpdateUserOutputPort,
                UpdateUserPresenter>();
            
            services.AddScoped<IUpgradeUserOutputPort,
                UpgradeUserPresenter>();

            return services;
        }
    }
}
