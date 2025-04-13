namespace Library.Features.WishlistBook.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddWishlistV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
