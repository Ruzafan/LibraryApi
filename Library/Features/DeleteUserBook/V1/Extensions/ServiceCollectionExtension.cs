namespace Library.Features.DeleteUserBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddDeleteUserBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
