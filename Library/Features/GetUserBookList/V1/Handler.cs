using Library.Features.GetUserBooksList.V1.Repositories;

namespace Library.Features.GetUserBooksList.V1
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
            var userBooks = await _repository.GetUserBooks(request.UserId, cancellationToken);
            if(userBooks == null) { return new Response(); }

            var books = await _repository.GetBooks(userBooks.Select(q=>q.BookId).ToList(), cancellationToken);
            if(books == null) { return new Response(); }

            return new Response()
            {
                Books = books.ToBookResponse()
            };
        }
    }
}
