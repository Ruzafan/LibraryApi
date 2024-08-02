using Library.Features.GetUserBooksList.V1.Repositories;

namespace Library.Features.GetUserBooksList.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddGetUserBooksListV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
