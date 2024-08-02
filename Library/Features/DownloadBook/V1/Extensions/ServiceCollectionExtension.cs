using Library.Features.DownloadBook.V1.Repositories;

namespace Library.Features.DownloadBook.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddDownloadBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
