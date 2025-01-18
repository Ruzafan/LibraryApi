
using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.GetBooksList.V1.Repositories
{
    public class Repository : IRepository
    {
        private IMongoCollection<Book> _mongoCollection;
        public Repository(MongoClient client)
        {
            var database = client.GetDatabase("Library");
            _mongoCollection = database.GetCollection<Book>("Books");
        }

        public async Task<List<Book>> GetBooks(int page, CancellationToken cancellationToken)
        {
            var filterBuilder = Builders<Book>.Filter;
            var filter = filterBuilder.Eq(q=> q.Status,Status.Active);
            return _mongoCollection.Find(filter).Limit(10).Skip(page-1).ToList();
        }
    }
}
