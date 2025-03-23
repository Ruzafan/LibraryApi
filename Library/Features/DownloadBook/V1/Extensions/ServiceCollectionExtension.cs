namespace Library.Features.DownloadBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddDownloadBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
