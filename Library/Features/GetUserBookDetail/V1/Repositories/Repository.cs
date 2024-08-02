using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.GetUserBookDetail.V1.Repositories
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

        public async Task<UserBook?> GetUserBook(string bookId, Guid userId, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<UserBook>();
            var filter = filterBuilder.And(filterBuilder.Eq(q => q.BookId, bookId),
                filterBuilder.Eq(q => q.UserId, userId)
                );
            return (await _mongoUserBookCollection.FindAsync(filter, cancellationToken: cancellationToken)).ToList().FirstOrDefault();
        }

        public async Task<Book?> GetBook(string bookId, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<Book>();
            var filter = filterBuilder.And(filterBuilder.Eq(q => q.Id, bookId));
            return (await _mongoBookCollection.FindAsync(filter, cancellationToken: cancellationToken)).ToList().FirstOrDefault();
        }
    }
}
