using MongoDB.Bson.Serialization.Attributes;

namespace Library.Entities
{
    [BsonIgnoreExtraElements]
    public class UserBook : Auditable
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public decimal Rating { get; set; }
        public string? Comments { get; set; }
        public List<string>? Genres { get; set; }
        public Ownership Ownership { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ReadingStatus ReadingStatus { get; set; }
    }
}
