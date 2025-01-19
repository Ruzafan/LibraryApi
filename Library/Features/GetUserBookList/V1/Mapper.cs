using Library.Entities;
using Library.Features.GetUserBooksList.V1;

namespace Library.Features.GetUserBookList.V1
{
    public static class Mapper
    {

        public static List<BookResponse> ToBookResponse(this List<Book> books)
          => books.Select(q => q.ToBookResponse()).ToList();
        public static BookResponse ToBookResponse(this Book bookEntity)
           => new BookResponse()
           {
               Title = bookEntity.Title,
               Image = bookEntity.Image
           };
    }
}
