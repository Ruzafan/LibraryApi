using Library.Entities;
using Library.Repositories;

namespace Library.Features.GetBookDetail.V1;

public class Handler(IRepository<Book> bookRepository)
{
    
    public async Task<Response?> Handle(Request request, CancellationToken cancellationToken = default)
    {
        var book = await bookRepository.Get(request.BookId, cancellationToken);
        if (book == null) return null;
        return book.ToResponse();
    }
}