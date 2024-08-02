using Library.Features.UpsertUserBook.V1.Repositories;

namespace Library.Features.UpsertUserBook.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddUpsertUserBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
