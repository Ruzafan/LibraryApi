using MongoDB.Driver;

namespace Library.Repositories;

public interface IRepository<T> where T : class
{
    public Task<List<T>> QueryItems(FilterDefinition<T> filterDefinition,
        CancellationToken cancellationToken = default);
    public Task<List<T>> QueryItems(FilterDefinition<T> filterDefinition, int page, int limit,
        CancellationToken cancellationToken = default);
    public Task<T?> Get(string id, CancellationToken cancellationToken);
    Task Add(T element, CancellationToken cancellationToken);
    Task<T> FindOne(FilterDefinition<T> filterDefinition,
        CancellationToken cancellationToken = default);
}