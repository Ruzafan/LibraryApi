
namespace Library.Features.GetBooksList.V1.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGetListBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
