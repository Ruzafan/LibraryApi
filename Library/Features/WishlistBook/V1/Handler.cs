using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.WishlistBook.V1
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
                builder.Eq(x => x.UserId, request.UserId),
                builder.Eq(x => x.Ownership, Ownership.WishList));
            var userBooks = await userBookRepository.QueryItems(filter,cancellationToken);
            if (userBooks != null && userBooks.Count != 0)
            {
                
                await userBookRepository.Delete(userBooks.FirstOrDefault().Id, cancellationToken);
            }
            else
            {
                await userBookRepository.Add(new UserBook()
                {
                    BookId = request.BookId,
                    CreationDate = DateTime.UtcNow,
                    UserId = request.UserId,
                    Ownership = Ownership.WishList,
                }, cancellationToken);
            }
            

            return new Response();
        }
    }
}
