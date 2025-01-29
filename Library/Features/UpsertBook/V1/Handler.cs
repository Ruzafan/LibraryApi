using Library.Entities;
using Library.Repositories;

namespace Library.Features.UpsertBook.V1
{
    public class Handler(IRepository<Book> bookRepository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            await bookRepository.Add(new Book(request.Title)
            {
                Image = request.Image,
                Status = Status.Active
            }, cancellationToken);
            return new Response();
        }
    }
}
