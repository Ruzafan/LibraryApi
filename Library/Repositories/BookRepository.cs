using Library.Entities;
using MongoDB.Driver;

namespace Library.Repository;

public class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _mongoCollection;

    public BookRepository(MongoClient client)
    {
        var database = client.GetDatabase("Library");
        _mongoCollection = database.GetCollection<Book>("Books");
    }

    public Task<List<Book>> QueryItems(FilterDefinition<Book> filterDefinition, int skip = 0, int limit = 100,
        CancellationToken cancellationToken = default)
    {
        return _mongoCollection.Find(filterDefinition).Limit(limit).Skip(skip).ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<Book> GetBook(string id, CancellationToken cancellationToken)
    {
        var filter = Builders<Book>.Filter.Eq(x => x.Id, id);
        
        return _mongoCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Book> AddBook(Book book, CancellationToken cancellationToken)
    {
        try
        {
            await _mongoCollection.InsertOneAsync(book, cancellationToken: cancellationToken);
        }
        catch (Exception ex)
        {
            throw ex;
            //TODO: Add logger
        }
        return book;
    }
}