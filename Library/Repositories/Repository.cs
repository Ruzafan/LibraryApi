using MongoDB.Driver;

namespace Library.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _mongoCollection;

    public Repository(MongoClient client)
    {
        var database = client.GetDatabase("Library");
        _mongoCollection = database.GetCollection<T>(nameof(T));
    }
    public Task<List<T>> QueryItems(FilterDefinition<T> filterDefinition, CancellationToken cancellationToken = default)
    {
        return _mongoCollection.Find(filterDefinition).ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<List<T>> QueryItems(FilterDefinition<T> filterDefinition, int page, int limit, CancellationToken cancellationToken = default)
    {
        return _mongoCollection.Find(filterDefinition)
            .Limit(limit)
            .Skip(page*limit)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<T?> Get(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", id);
        
        return _mongoCollection.Find(filter).FirstAsync(cancellationToken);
    }

    public async Task Add(T element, CancellationToken cancellationToken)
    {
        await _mongoCollection.InsertOneAsync(element, cancellationToken: cancellationToken);
    }

    public Task<T?> FindOne(FilterDefinition<T> filterDefinition, CancellationToken cancellationToken = default)
    {
        return _mongoCollection.Find(filterDefinition).SingleAsync(cancellationToken: cancellationToken);
    }
}

