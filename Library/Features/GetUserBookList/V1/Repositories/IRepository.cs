using Library.Entities;

namespace Library.Features.GetUserBooksList.V1.Repositories
{
    public interface IRepository
    {
        public Task<List<UserBook>> GetUserBooks(Guid userId, CancellationToken cancellationToken);
        public Task<List<Book>> GetBooks(List<string> bookIds, CancellationToken cancellationToken);
    }
}
