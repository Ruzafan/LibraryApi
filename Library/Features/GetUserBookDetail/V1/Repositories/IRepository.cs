using Library.Entities;

namespace Library.Features.GetUserBookDetail.V1.Repositories
{
    public interface IRepository
    {
        public Task<UserBook> GetUserBook(string bookId, Guid userId, CancellationToken cancellationToken);
        public Task<Book> GetBook(string bookId, CancellationToken cancellationToken);
    }
}
