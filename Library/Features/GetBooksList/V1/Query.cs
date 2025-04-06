using System.Text.RegularExpressions;
using Library.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Library.Features.GetBooksList.V1;

public static class Query
{
    public static FilterDefinition<Book> GetFilter(string filter)
    {
        var filterBuilder = Builders<Book>.Filter;
        
        var regexOptions = new RegexOptions[] { RegexOptions.IgnoreCase }; 

        var filterDefinition = filterBuilder.Or(
            filterBuilder.Regex(b => b.Title, new BsonRegularExpression(filter, string.Join("", regexOptions.Select(r => r.ToString().Substring(0,1).ToLower())))),
            filterBuilder.Regex(b => b.Authors, new BsonRegularExpression(filter, string.Join("", regexOptions.Select(r => r.ToString().Substring(0, 1).ToLower()))))
        );
        return !string.IsNullOrWhiteSpace(filter) 
            ? filterBuilder.And(filterDefinition,filterBuilder.Eq(q=> q.Status,Status.Active) ) 
            : filterBuilder.Eq(q=> q.Status,Status.Active);
    }
}