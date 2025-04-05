
namespace Library.Features.CreateBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddCreateBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
