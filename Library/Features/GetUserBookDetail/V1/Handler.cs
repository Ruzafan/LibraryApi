
using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.GetUserBookDetail.V1
{
    public class Handler (IRepository<Book> bookRepository, IRepository<UserBook> userBookRepository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var response = new Response();
            var filter = Builders<UserBook>.Filter;
            var userFilter = Builders<UserBook>.Filter.And(
                filter.Eq(u => u.BookId, request.BookId),
                filter.Eq(u => u.UserId, request.UserId)
            ); 
            var userBook = (await userBookRepository.QueryItems(userFilter, cancellationToken)).FirstOrDefault();

            if (userBook is null) return response;
            var book = await bookRepository.Get(request.BookId, cancellationToken);
            if(book is not null)
            {
                response.Book = userBook.ToBookResponse(book);
            }

            return response;
        }
    }
}
