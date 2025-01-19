namespace Library.Features.UpsertUserBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddUpsertUserBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
