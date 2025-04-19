using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.GetUserBookList.V1
{
    public class Handler(IRepository<UserBook> repository, IRepository<Book> bookRepository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var userBookFilter = Builders<UserBook>.Filter;
            
            var userFilter = userBookFilter.And(userBookFilter.Eq(u => u.UserId, request.UserId)
                , userBookFilter.In(q=>q.Ownership, [Ownership.Owned,Ownership.Rented]));
            var userBooks = await repository.QueryItems(userFilter, cancellationToken);
            if(userBooks.Count == 0) { return new Response(); }

            var filter = Builders<Book>.Filter.In(b => b.Id, userBooks.Select(q => q.BookId).ToList());
            var books = await bookRepository.QueryItems(filter, cancellationToken:cancellationToken);
            if(books.Count == 0) { return new Response(); }

            return new Response()
            {
                Books = books.ToBookResponse(userBooks)
            };
        }
    }
}
