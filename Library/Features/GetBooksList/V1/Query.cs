using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.GetBooksList.V1;

public static class Query
{
    public static FilterDefinition<Book> GetFilter(string filter)
    {
        var filterBuilder = Builders<Book>.Filter;
        
        var filterDefinition = filterBuilder.Or(
            filterBuilder.Regex(b => b.Title, filter),
            filterBuilder.Regex(b => b.Authors, filter)
            );
        return !string.IsNullOrWhiteSpace(filter) 
            ? filterBuilder.And(filterDefinition,filterBuilder.Eq(q=> q.Status,Status.Active) ) 
            : filterBuilder.Eq(q=> q.Status,Status.Active);
    }
}