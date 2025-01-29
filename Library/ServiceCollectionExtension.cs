using Library.Entities;
using Library.Features.GetBookDetail.V1;
using Library.Features.GetBooksList.V1;
using Library.Features.GetBooksList.V1.Extensions;
using Library.Features.GetUserBookDetail.V1;
using Library.Features.GetUserBookDetail.V1.Extensions;
using Library.Features.GetUserBookList.V1.Extensions;
using Library.Features.UpsertBook.V1.Extensions;
using Library.Features.UpsertUserBook.V1.Extensions;
using Library.Repositories;
using MongoDB.Driver;

namespace Library;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration.GetValue<string>("MONGODB_URI"));
        services.AddSingleton(mongoClient);
        return services;
    }

    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        services.AddGetListBookV1();
        services.AddUpsertBookV1();
        services.AddUpsertUserBookV1();
        services.AddGetUserBookV1();
        services.AddGetUserBooksListV1();
        services.AddSingleton<IRepository<Book>, Repository<Book>>();
        services.AddSingleton<IRepository<UserBook>, Repository<UserBook>>();
        return services;
    }

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGetListEndpoint();
        app.MapGetDetailEndpoint();
        app.MapBookDetailEndpoint();
    }
}