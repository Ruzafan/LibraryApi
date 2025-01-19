using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.GetBooksList.V1;

public static class Query
{
    public static FilterDefinition<Book> GetFilter()
    {
        var filterBuilder = Builders<Book>.Filter;
        return filterBuilder.Eq(q=> q.Status,Status.Active);
    }
}