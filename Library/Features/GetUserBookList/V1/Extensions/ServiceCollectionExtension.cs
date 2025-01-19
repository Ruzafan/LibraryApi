namespace Library.Features.GetUserBookList.V1.Extensions
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddGetUserBooksListV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            return services;
        }
    }
}
