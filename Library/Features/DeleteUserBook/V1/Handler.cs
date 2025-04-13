using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.DeleteUserBook.V1
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
            
            var builder =Builders<UserBook>.Filter;
            var filter = builder.And( builder.Eq(x => x.BookId, request.BookId),
                builder.Eq(x => x.UserId, request.UserId));
            

            var userBooks = await userBookRepository.QueryItems(filter,cancellationToken);
            if (userBooks == null || userBooks.Count == 0)
            {
                return new Response().AddError("Book not found", $"The Book with id {request.BookId} has not been found.");
            }
            await userBookRepository.Delete(userBooks.FirstOrDefault().Id, cancellationToken);

            return new Response();
        }
    }
}
