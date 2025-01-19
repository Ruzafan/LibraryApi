using Library.Entities;
using MongoDB.Driver;

namespace Library.Repository;

public interface IBookRepository
{
    public Task<List<Book>> QueryItems(FilterDefinition<Book> filterDefinition, int skip = 0, int limit = 100,
        CancellationToken cancellationToken = default);

    public Task<Book?> GetBook(string id, CancellationToken cancellationToken);
    
    public Task<Book> AddBook(Book book, CancellationToken cancellationToken);
}