using Library.Repository;

namespace Library.Features.UpsertBook.V1
{
    public class Handler(IBookRepository bookRepository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            await bookRepository.AddBook(new Entities.Book(request.Title)
            {
                Image = request.Image,
                Status = Entities.Status.Active
            }, cancellationToken);
            return new Response();
        }
    }
}
