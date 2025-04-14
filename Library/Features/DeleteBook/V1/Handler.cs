using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.DeleteBook.V1
{
    public class Handler(IRepository<Book> bookRepository)
    {

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.Get(request.BookId, cancellationToken);
            if(book == null)
            {
                return new Response().AddError("Book not found", $"The Book with id {request.BookId} has not been found.");
            }
            
            await bookRepository.Delete(request.BookId,cancellationToken);
            
            return new Response();
        }
    }
}
