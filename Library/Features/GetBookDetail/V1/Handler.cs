using Library.Repository;

namespace Library.Features.GetBookDetail.V1;

public class Handler(IBookRepository bookRepository)
{
    
    public async Task<Response?> Handle(Request request, CancellationToken cancellationToken = default)
    {
        var book = await bookRepository.GetBook(request.BookId, cancellationToken);
        if (book == null) return null;
        return book.ToResponse();
    }
}