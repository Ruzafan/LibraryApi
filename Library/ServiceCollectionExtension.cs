using Library.Features.DownloadBook.V1;
using Library.Features.DownloadBook.V1.Extensions;
using Library.Features.GetBooksList.V1.Extensions;
using Library.Features.GetUserBookDetail.V1;
using Library.Features.GetUserBookDetail.V1.Extensions;
using Library.Features.GetUserBookList.V1.Extensions;
using Library.Features.GetUserBooksList.V1;
using Library.Features.UpsertBook.V1;
using Library.Features.UpsertBook.V1.Extensions;
using Library.Features.UpsertUserBook.V1;
using Library.Features.UpsertUserBook.V1.Extensions;
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
        services.AddDownloadBookV1();
        services.AddSingleton<Repository.IBookRepository, Repository.BookRepository>();
        services.AddSingleton<Repository.IUserBookRepository, Repository.UserBookRepository>();
        return services;
    }
}