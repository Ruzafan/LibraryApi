namespace Library.Features.DeleteBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddDeleteBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
