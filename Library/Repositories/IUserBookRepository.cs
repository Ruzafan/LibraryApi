using Library.Entities;
using MongoDB.Driver;

namespace Library.Repository;

public interface IUserBookRepository
{
    public Task<List<UserBook>> QueryItems(FilterDefinition<UserBook> filterDefinition,
        CancellationToken cancellationToken = default);

    public Task<UserBook> GetUserBook(string id, CancellationToken cancellationToken);
    Task AddUserBook(UserBook userBook, CancellationToken cancellationToken);
}