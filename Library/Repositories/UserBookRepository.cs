using Library.Entities;
using MongoDB.Driver;

namespace Library.Repository;

public class UserBookRepository : IUserBookRepository
{
    
    private readonly IMongoCollection<UserBook> _mongoCollection;

    public UserBookRepository(MongoClient client)
    {
        var database = client.GetDatabase("Library");
        _mongoCollection = database.GetCollection<UserBook>("UserBooks");
    }
    public Task<List<UserBook>> QueryItems(FilterDefinition<UserBook> filterDefinition, CancellationToken cancellationToken = default)
    {
        return _mongoCollection.Find(filterDefinition).ToListAsync(cancellationToken: cancellationToken);

    }

    public Task<UserBook> GetUserBook(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<UserBook>.Filter.Eq(x => x.Id, id);
        
        return _mongoCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddUserBook(UserBook userBook, CancellationToken cancellationToken)
    {
        await _mongoCollection.InsertOneAsync(userBook, cancellationToken: cancellationToken);
    }
}