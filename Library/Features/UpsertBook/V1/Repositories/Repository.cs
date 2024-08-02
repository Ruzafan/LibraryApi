using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.UpsertBook.V1.Repositories
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
            InsertOneOptions options = new InsertOneOptions();
            await _mongoCollection.InsertOneAsync(book, options, cancellationToken);
        }
    }
}
