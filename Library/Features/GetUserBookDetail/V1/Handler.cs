using Library.Features.GetUserBookDetail.V1.Repositories;

namespace Library.Features.GetUserBookDetail.V1
{
    public class Handler
    {
        private IRepository _repository;
        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var response = new Response();

            var userBook = await _repository.GetUserBook(request.BookId,request.UserId, cancellationToken);
            
            if (userBook is not null)
            {
                var book = await _repository.GetBook(request.BookId, cancellationToken);
                if(book is not null)
                {
                    response.Book = userBook.ToBookResponse(book);
                }
            }

            return response;
        }
    }
}
