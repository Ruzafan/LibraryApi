using Library.Entities;
using MongoDB.Driver;

namespace Library.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserBook> _mongoCollection;

    public UserRepository(MongoClient client)
    {
        var database = client.GetDatabase("Library");
        _mongoCollection = database.GetCollection<UserBook>("User");
    }
    public Task<User?> GetUser(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}