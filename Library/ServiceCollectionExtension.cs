using System.Text;
using Library.Entities;
using Library.Features.CreateBook.V1;
using Library.Features.CreateBook.V1.Extensions;
using Library.Features.DownloadBook.V1;
using Library.Features.DownloadBook.V1.Extensions;
using Library.Features.GetBookDetail.V1;
using Library.Features.GetBookDetail.V1.Extensions;
using Library.Features.GetBooksList.V1;
using Library.Features.GetBooksList.V1.Extensions;
using Library.Features.GetUserBookDetail.V1;
using Library.Features.GetUserBookDetail.V1.Extensions;
using Library.Features.GetUserBookList.V1;
using Library.Features.GetUserBookList.V1.Extensions;
using Library.Features.UpsertBook.V1;
using Library.Features.UpsertBook.V1.Extensions;
using Library.Features.UpsertUserBook.V1;
using Library.Features.UpsertUserBook.V1.Extensions;
using Library.Features.WishlistBook.V1;
using Library.Features.WishlistBook.V1.Extensions;
using Library.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
        services.AddGetBookV1();
        services.AddDownloadBookV1();
        services.AddCreateBookV1();
        services.AddWishlistV1();
        services.AddSingleton<IRepository<Book>, Repository<Book>>();
        services.AddSingleton<IRepository<UserBook>, Repository<UserBook>>();
        return services;
    }

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGetBookListEndpoint();
        app.MapGetBookDetailEndpoint();
        app.MapUserBookDetailEndpoint();
        app.MapUserBookListEndpoint();
        app.MapUpsertBookEndpoint();
        app.MapUpsertUserBookEndpoint();
        app.MapDownloadBookEndpoint();
        app.MapCreateBookEndpoint();
        app.MapWishedEndpoint();
    }
    
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "your_issuer",
                ValidAudience = "your_audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("SecretKey","")))
            };
        });
        return services;
    }
}