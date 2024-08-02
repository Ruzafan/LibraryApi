using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.UpsertUserBook.V1.Repositories
{
    public class Repository : IRepository
    {
        private IMongoCollection<UserBook> _mongoUserBookCollection;
        private IMongoCollection<Book> _mongoBookCollection;
        public Repository(MongoClient client)
        {
            var database = client.GetDatabase("Library");
            _mongoUserBookCollection = database.GetCollection<UserBook>("UserBooks");
            _mongoBookCollection = database.GetCollection<Book>("Books");
        }

        public async Task AddUserBook(UserBook userBook, CancellationToken cancellationToken)
        {
            InsertOneOptions options = new InsertOneOptions();
            await _mongoUserBookCollection.InsertOneAsync(userBook, options, cancellationToken);
        }

        public async Task<bool> ExistBook(string bookId, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<Book>();
            var filter = filterBuilder.And(filterBuilder.Eq(q => q.Id, bookId));
            try
            {
                return (await _mongoBookCollection.FindAsync(filter, cancellationToken: cancellationToken)).Any();
            }catch( Exception ex)
            {
                return false;
            }
        }
    }
}
