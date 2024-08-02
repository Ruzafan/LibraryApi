
namespace Library.Features.UpsertUserBook.V1
{
    public class Request{
        public string BookId { get; set; }
        public Guid UserId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
    }
}