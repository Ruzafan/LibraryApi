using Library.Features.UpsertUserBook.V1.Repositories;

namespace Library.Features.UpsertUserBook.V1
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
            if(! await _repository.ExistBook(request.BookId, cancellationToken))
            {
                return new Response().AddError("Book not found", $"The Book with id {request.BookId} has not been found.");
            }
            await _repository.AddUserBook(new Entities.UserBook()
            {
                BookId = request.BookId,
                Comments = request.Comments,
                CreationDate = DateTime.UtcNow,
                UserId = request.UserId,
                Rating = request.Rating
            }, cancellationToken);

            return new Response();
        }
    }
}
