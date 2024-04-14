using Microsoft.Extensions.DependencyInjection;
using UseCases.CategoryContentUC;
using UseCases.CategoryUC;
using UseCases.ContentUC;
using UseCases.HystoryPlaybackUC;
using UseCases.UserUC;
using UseCasesPort.CategoryContentPorts.Inputs;
using UseCasesPort.CategoryPorts.Inputs;
using UseCasesPort.ContentPorts.Inputs;
using UseCasesPort.HistoryPlaybackPorts.Inputs;
using UseCasesPort.UserPort.Inputs;

namespace UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            //CategoryContent
            services.AddTransient
                <ICreateCategoryContentInputPort, CreateCategoryContentInteractor>();
            services.AddTransient
                <IDeleteCategoryContentInputPort, DeleteCategoryContentInteractor>();
            services.AddTransient
                <IReadAllCategoryContentInputPort, ReadAllCategoryContentInteractor>();
            services.AddTransient
                <IReadCategoryContentInputPort, ReadCategoryContentInteractor>();
            services.AddTransient
                <IUpdateCategoryContentInputPort, UpdateCategoryContentInteractor>();

            //Category
            services.AddTransient
                <ICreateCategoryInputPort, CreateCategoryInteractor>();
            services.AddTransient
                <IDeleteCategoryInputPort, DeleteCategoryInteractor>();
            services.AddTransient
                <IReadAllCategoryInputPort, ReadAllCategoryInteractor>();
            services.AddTransient
                <IReadCategoryInputPort, ReadCategoryInteractor>();
            services.AddTransient
                <IUpdateCategoryInputPort, UpdateCategoryInteractor>();

            //Content
            services.AddTransient
                <ICreateContentInputPort, CreateContentInteractor>();
            services.AddTransient
                <IDeleteContentInputPort, DeleteContentInteractor>();
            services.AddTransient
                <IReadAllContentInputPort, ReadAllContentInteractor>();
            services.AddTransient
                <IReadContentInputPort, ReadContentInteractor>();
            services.AddTransient
                <IUpdateContentInputPort, UpdateContentInteractor>();
            services.AddTransient
                <IViewContentInputPort, ViewContentInteractor>();

            //HistoryPlayback
            services.AddTransient
                <ICreateHistoryPlaybackInputPort, CreateHistoryPlaybackInteractor>();
            services.AddTransient
                <IDeleteHistoryPlaybackInputPort, DeletehistoryPlayblackInteractor>();
            services.AddTransient
                <IReadAllHistoryPlaybackInputPort, ReadAllHistoryPlaybackInteractor>();
            services.AddTransient
                <IReadHistoryPlaybackInputPort, ReadHistoryPlaybackInteractor>();
            services.AddTransient
                <IUpdateHistoryPlaybackInputPort, UpdateHistoryPlaybackInteractor>();

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
            
            return services;
        }
    }
}
