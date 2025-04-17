using Library.Entities;

namespace Library.Features.GetUserBookList.V1
{
    public static class Mapper
    {

        public static List<BookResponse> ToBookResponse(this List<Book> books, List<UserBook> userBooks)
          => books.Select(q => q.ToBookResponse(userBooks.FirstOrDefault(ub => ub.BookId == q.Id))).ToList();

        private static BookResponse ToBookResponse(this Book bookEntity, UserBook userBook)
           => new BookResponse()
           {
               Title = bookEntity.Title,
               Image = bookEntity.Image,
               Id = bookEntity.Id,
               Genres = userBook.Genres,
           };
    }
}
