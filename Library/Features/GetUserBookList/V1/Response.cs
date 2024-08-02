using Library.Entities;

namespace Library.Features.GetUserBooksList.V1
{
    public class Response
    {
        public List<BookResponse> Books { get; set; }
    }
}
