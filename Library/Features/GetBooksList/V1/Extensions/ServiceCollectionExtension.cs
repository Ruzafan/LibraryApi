using Library.Features.GetBooksList.V1.Repositories;

namespace Library.Features.GetBooksList.V1.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void MapGetListEndpoint(this WebApplication app)
        {
            app.MapGet("/getbookslist/v1", async (int page, CancellationToken cancellationToken, Handler handler) =>
                {
                    var response = await handler.Handle(page, cancellationToken);
                    return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
                })
                .WithName("GetBooksList");
        }
        
        public static IServiceCollection AddGetListBookV1(this IServiceCollection services)
        {
            services.AddSingleton<Handler>();
            services.AddSingleton<IRepository, Repository>();
            return services;
        }
    }
}
