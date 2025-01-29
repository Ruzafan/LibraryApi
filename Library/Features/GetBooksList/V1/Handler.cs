using Library.Entities;
using Library.Repositories;

namespace Library.Features.GetBooksList.V1
{
    public class Handler(IRepository<Book> bookRepository)
    {
        public async Task<Response> Handle(int page, CancellationToken cancellationToken = default)
        {
            var bookEntity = await bookRepository.QueryItems(
                Query.GetFilter(),
                page - 1,
                100,
                cancellationToken);
            return new Response
            {
                Books = bookEntity.Select(q => q.ToBook()).ToList()
            };
        }
    }
}