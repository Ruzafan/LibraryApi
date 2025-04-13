using Library.Entities;

namespace Library.Features.GetUserBookDetail.V1
{
    public static class Mapper
    {
        public static BookResponse ToBookResponse(this UserBook userBook, Book book)
          => new()
          {
              Title = book.Title,
              Image = book.Image,
              Rating = userBook.Rating,
              Comments = userBook.Comments,
              Id = userBook.BookId,
              Genres = (userBook.Genres ?? book.Genres) ?? [],
          };
       
    }
}
