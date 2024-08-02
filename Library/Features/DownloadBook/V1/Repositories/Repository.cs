using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.DownloadBook.V1.Repositories
{
    public class Repository : IRepository
    {
        private IMongoCollection<Book> _mongoCollection;
        public Repository(MongoClient client)
        {
            var database = client.GetDatabase("Library");
            _mongoCollection = database.GetCollection<Book>("Books");
        }

        public async Task AddBook(Book book, CancellationToken cancellationToken)
        {
            ReplaceOptions options = new ReplaceOptions()
            {
                IsUpsert = true,
            };
            var filter = Builders<Book>.Filter.Eq(q=>q.Id, book.Id);
            await _mongoCollection.ReplaceOneAsync(filter, book, options, cancellationToken);
        }
    }
}
