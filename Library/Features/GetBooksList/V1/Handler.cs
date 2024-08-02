using Library.Features.GetBooksList.V1.Repositories;

namespace Library.Features.GetBooksList.V1
{
    public class Handler
    {
        private IRepository _repository;
        public Handler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(int page, CancellationToken cancellationToken = default)
        {
            var bookEntity = await _repository.GetBooks(page,cancellationToken);
            return new Response
            {
                Books = bookEntity.Select(q=> q.ToBook()).ToList()
            };
        }
    }
}
