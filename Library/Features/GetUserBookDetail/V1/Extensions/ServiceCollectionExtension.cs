namespace Library.Features.GetUserBookDetail.V1.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddGetUserBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
