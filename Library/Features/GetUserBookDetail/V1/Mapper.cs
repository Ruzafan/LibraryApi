using Library.Entities;

namespace Library.Features.GetUserBookDetail.V1
{
    public static class Mapper
    {
        public static BookResponse ToBookResponse(this UserBook userbook, Book book)
          => new()
          {
              Title = book.Title,
              Image = book.Image,
              Rating = userbook.Rating,
              Comments = userbook.Comments
          };
       
    }
}
