
namespace Library.Features.UpsertBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddUpsertBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
