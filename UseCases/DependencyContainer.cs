using Microsoft.Extensions.DependencyInjection;
using UseCases.UserUC;
using UseCasesPort.UserPort.Inputs;

namespace UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            //User
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
                <IUpgradeUserInputPort,UpgradeUserInteractor>();
            //
            return services;
        }
    }
}
