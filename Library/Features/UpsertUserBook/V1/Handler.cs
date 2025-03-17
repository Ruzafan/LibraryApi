using Library.Entities;
using Library.Repositories;

namespace Library.Features.UpsertUserBook.V1
{
    public class Handler(IRepository<UserBook> userBookRepository, IRepository<Book> bookRepository)
    {

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.Get(request.BookId, cancellationToken);
            if(book == null)
            {
                return new Response().AddError("Book not found", $"The Book with id {request.BookId} has not been found.");
            }
            await userBookRepository.Add(new UserBook()
            {
                BookId = request.BookId,
                Comments = request.Comments,
                CreationDate = DateTime.UtcNow,
                UserId = request.UserId,
                Rating = request.Rating,
                StatusType = request.GetStatusType()
            }, cancellationToken);

            return new Response();
        }
    }
}
