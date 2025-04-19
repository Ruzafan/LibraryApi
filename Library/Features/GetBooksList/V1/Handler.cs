using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.GetBooksList.V1
{
    public class Handler(IRepository<Book> bookRepository, IRepository<UserBook> userBookRepository)
    {
        public async Task<Response> Handle(string filter, int page, int rows, string userId, CancellationToken cancellationToken = default)
        {
            var bookEntity = await bookRepository.QueryItems(
                Query.GetFilter(filter),
                page - 1,
                rows,
                cancellationToken);

            List<string> wishedBooks = [];
            if (!string.IsNullOrEmpty(userId))
            {
                var userBookFilter = Builders<UserBook>.Filter.And(
                    Builders<UserBook>.Filter.Eq(ub => ub.UserId, userId),
                    Builders<UserBook>.Filter.In(ub => ub.BookId, bookEntity.Select(b => b.Id)),
                    Builders<UserBook>.Filter.Eq(ub => ub.Ownership, Ownership.WishList)
                );
                var userBooks = await userBookRepository.QueryItems(userBookFilter, cancellationToken);
                wishedBooks = userBooks.Select(q => q.BookId).ToList();
            }
            return new Response
            {
                Books = bookEntity.Select(q => q.ToBook(wishedBooks)).ToList()
            };
        }
    }
}