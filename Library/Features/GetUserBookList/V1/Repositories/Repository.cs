using Library.Entities;
using MongoDB.Driver;

namespace Library.Features.GetUserBooksList.V1.Repositories
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

        public async Task<List<Book>> GetBooks(List<string> bookIds, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<Book>();
            var filter = filterBuilder.In(q => q.Id, bookIds);
            return (await _mongoBookCollection.FindAsync(filter, cancellationToken: cancellationToken)).ToList();
        }

        public async Task<List<UserBook>> GetUserBooks(Guid userId, CancellationToken cancellationToken)
        {
            var filterBuilder = new FilterDefinitionBuilder<UserBook>();
            var filter = filterBuilder.Eq(q=>q.UserId, userId);
            return (await _mongoUserBookCollection.FindAsync(filter, cancellationToken: cancellationToken)).ToList();
        }
    }
}
