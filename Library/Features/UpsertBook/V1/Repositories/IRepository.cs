using Library.Entities;

namespace Library.Features.UpsertBook.V1.Repositories
{
    public interface IRepository {
        public Task AddBook(Book book, CancellationToken cancellationToken);
    }
}