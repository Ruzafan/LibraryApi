using Library.Entities;

namespace Library.Features.UpsertUserBook.V1.Repositories
{
    public interface IRepository {
        public Task AddUserBook(UserBook book, CancellationToken cancellationToken);
        public Task<bool> ExistBook(string bookId, CancellationToken cancellationToken);
    }
}