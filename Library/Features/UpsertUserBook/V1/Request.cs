
using Library.Entities;

namespace Library.Features.UpsertUserBook.V1
{
    public class Request{
        public string BookId { get; set; }
        public string UserId { get; set; }
        public string Comments { get; set; }
        public List<string> Genres { get; set; }
        public int Rating { get; set; }
        public Ownership Ownership { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
    }
}