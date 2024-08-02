using Library.Features.UpsertBook.V1.Repositories;

namespace Library.Features.UpsertBook.V1
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
            await _repository.AddBook(new Entities.Book(request.Title)
            {
                Image = request.Image,
                Status = Entities.Status.Active
            }, cancellationToken);
            return new Response();
        }
    }
}
