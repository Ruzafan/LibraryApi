namespace Library.Features.GetBookDetail.V1.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGetBookV1(this IServiceCollection services)
    {
        services.AddSingleton<Handler>();
        return services;
    }
}