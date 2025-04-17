using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.GetBookDetail.V1;

public class Handler(IRepository<Book> bookRepository, IRepository<UserBook> userBookRepository)
{
    
    public async Task<Response?> Handle(Request request, CancellationToken cancellationToken = default)
    {
        var book = await bookRepository.Get(request.BookId, cancellationToken);
        if (book == null) return null;
        var userBookFilter = Builders<UserBook>.Filter;
        var userFilter = userBookFilter.And(userBookFilter.Eq(u => u.UserId, request.UserId),
            userBookFilter.Eq(u => u.BookId, request.BookId),
            userBookFilter.Eq(u => u.StatusType, StatusType.Owned));
        var userBooks = await userBookRepository.QueryItems(userFilter, cancellationToken);
        
        return book.ToResponse(userBooks.FirstOrDefault());
    }
}