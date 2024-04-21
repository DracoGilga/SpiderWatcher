using Microsoft.Extensions.DependencyInjection;
using UseCases.UserUC;
using UseCasesPort.UserPort.Inputs;

namespace UseCases.DependencyContainers
{
    public static class User
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddTransient
                <ICreateUserInputPort, CreateUserInteractor>();
            services.AddTransient
                <IDeleteUserInputPort, DeleteUserInteractor>();
            services.AddTransient
                <IReadAllUsersInputPort, ReadAllUsersInteractor>();
            services.AddTransient
                <IReadUserInputPort, ReadUserInteractor>();
            services.AddTransient
                <IUpdatePasswordUserInputPort, UpdatePasswordUserInteractor>();
            services.AddTransient
                <IUpdateUserInputPort, UpdateUserInteractor>();
            services.AddTransient
                <ILoginUserInputPort, LoginUserInteractor>();
            services.AddTransient
                <IUpgradeUserInputPort, UpgradeUserInteractor>();

            return services;
        }
    }
}
