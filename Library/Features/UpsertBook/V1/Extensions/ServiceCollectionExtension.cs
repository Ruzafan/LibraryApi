using Library.Features.UpsertBook.V1.Repositories;

namespace Library.Features.UpsertBook.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddUpsertBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
