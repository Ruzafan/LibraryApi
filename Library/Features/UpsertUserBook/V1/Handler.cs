using Library.Repository;

namespace Library.Features.UpsertUserBook.V1
{
    public class Handler(IUserBookRepository userBookRepository, IBookRepository bookRepository)
    {

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.GetBook(request.BookId, cancellationToken);
            if(book == null)
            {
                return new Response().AddError("Book not found", $"The Book with id {request.BookId} has not been found.");
            }
            await userBookRepository.AddUserBook(new Entities.UserBook()
            {
                BookId = request.BookId,
                Comments = request.Comments,
                CreationDate = DateTime.UtcNow,
                UserId = request.UserId,
                Rating = request.Rating
            }, cancellationToken);

            return new Response();
        }
    }
}
