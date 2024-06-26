﻿using Microsoft.Extensions.DependencyInjection;
using Presenters.User;
using UseCasesPort.UserPort.Outputs;

namespace Presenters.DependencyContainers
{
    public static class User
    {
        public static IServiceCollection AddUserPresenters(
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
            services.AddScoped<IRecoverPasswordOutputPort,
                RecoverPasswordPresenter>();

            return services;
        }
    }
}
