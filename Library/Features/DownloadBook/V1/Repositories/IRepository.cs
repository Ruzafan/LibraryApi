using Library.Entities;

namespace Library.Features.DownloadBook.V1.Repositories
{
    public interface IRepository {
        public Task AddBook(Book book, CancellationToken cancellationToken);
    }
}