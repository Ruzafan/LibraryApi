using Library.Entities;

namespace Library.Features.GetBooksList.V1
{
    public static class Mapper
    {
        public static BookResponse ToBook(this Book bookEntity)
           => new BookResponse()
           {
               Id = bookEntity.Id,
               Title = bookEntity.Title,
               Image = bookEntity.Image
           };
    }
}
