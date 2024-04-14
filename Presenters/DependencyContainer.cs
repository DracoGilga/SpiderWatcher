using Microsoft.Extensions.DependencyInjection;
using Presenters.Category;
using Presenters.Content;
using Presenters.HistoryPlayback;
using Presenters.User;
using UseCasesPort.CategoryPorts.Outputs;
using UseCasesPort.ContentPorts.Outputs;
using UseCasesPort.HistoryPlaybackPorts.Outputs;
using UseCasesPort.UserPort.Outputs;

namespace Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            //Category
            services.AddScoped<ICreateCategoryOutputPort, 
                               CreateCategoryPresenter>();
            services.AddScoped<IDeleteCategoryOutputPort,
                DeleteCategoryPresenter>();
            services.AddScoped<IReadAllCategoryOutputPort,
                ReadAllCategoryPresenter>();
            services.AddScoped<IReadCategoryOutputPort,
                ReadCategoryPresenter>();
            services.AddScoped<IUpdateCategoryOutputPort,
                UpdateCategoryPresenter>();

            //Content
            services.AddScoped<ICreateContentOutputPort, 
                CreateContentPresenter>();
            services.AddScoped<IDeleteContentOutputPort,
                DeleteContentPresenter>();
            services.AddScoped<IReadAllContentOutputPort,
                ReadAllContentPresenter>();
            services.AddScoped<IReadContentOutputPort,
                ReadContentPresenter>();
            services.AddScoped<IUpdateContentOutputPort,
                UpdateContentPresenter>();
            services.AddScoped<IViewContentOutputPort,
                ViewContentPresenter>();

            //HistoryPlayback
            services.AddScoped<ICreateHistoryPlaybackOutputPort, 
                CreateHistoryPlaybackPresenter>();
            services.AddScoped<IDeleteHistoryPlaybackOutputPort, 
                DeleteHistoryPlaybackPresenter>();
            services.AddScoped<IReadAllHistoryPlaybackOutputPort,
                ReadAllHistoryPlaybackPresenter>();
            services.AddScoped<IReadHistoryPlaybackOutputPort,
                ReadHistoryPlaybackPresenter>();
            services.AddScoped<IUpdateHistoryPlaybackOutputPort,
                UpdadeHistoryPlaybackPresenter>();

            //User
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
