using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.UpsertUserBook.V1
{
    public class Handler(IRepository<UserBook> userBookRepository, IRepository<Book> bookRepository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.Get(request.BookId, cancellationToken);
            if (book == null)
            {
                return new Response().AddError("Book not found",
                    $"The Book with id {request.BookId} has not been found.");
            }

            var builder = Builders<UserBook>.Filter;
            var filter = builder.And(builder.Eq(x => x.BookId, request.BookId),
                builder.Eq(x => x.UserId, request.UserId));


            var userBooks = await userBookRepository.QueryItems(filter, cancellationToken);
            if (userBooks != null && userBooks.Count != 0)
            {
                var userBookBuilder = Builders<UserBook>.Update.Combine(
                    Builders<UserBook>.Update.Set(x => x.Comments, request.Comments),
                    Builders<UserBook>.Update.Set(x => x.Genres, request.Genres),
                    Builders<UserBook>.Update.Set(x => x.LastModifiedDate, DateTime.UtcNow),
                    Builders<UserBook>.Update.Set(x => x.Rating, request.Rating)
                );
                await userBookRepository.Update(userBooks.FirstOrDefault().Id, userBookBuilder, cancellationToken);
            }
            else
            {
                await userBookRepository.Add(new UserBook()
                {
                    BookId = request.BookId,
                    Comments = request.Comments,
                    CreationDate = DateTime.UtcNow,
                    UserId = request.UserId,
                    Rating = request.Rating,
                    StatusType = request.GetStatusType(),
                    Genres = request.Genres
                }, cancellationToken);
            }

            return new Response();
        }
    }
}