using Library.Entities;

namespace Library.Features.GetBooksList.V1.Repositories
{
    public interface IRepository {
        public Task<List<Book>> GetBooks(int page, CancellationToken cancellationToken);
    }
}