
using Library.Entities;

namespace Library.Features.DeleteUserBook.V1
{
    public class Request{
        public string BookId { get; set; }
        public string UserId { get; set; }
        
    }
}