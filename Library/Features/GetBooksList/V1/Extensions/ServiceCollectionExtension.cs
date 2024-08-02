using Library.Features.GetBooksList.V1.Repositories;

namespace Library.Features.GetBooksList.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddGetListBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
