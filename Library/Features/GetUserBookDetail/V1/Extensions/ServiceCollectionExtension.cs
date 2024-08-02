using Library.Features.GetUserBookDetail.V1.Repositories;

namespace Library.Features.GetUserBookDetail.V1
{
    public static class ServiceCollectionExtension
    {

        public static IServiceCollection AddGetUserBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
