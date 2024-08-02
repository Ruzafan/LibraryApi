namespace Library.Entities
{
    public class UserBook : Auditable
    {
        public Guid UserId { get; set; }
        public string BookId { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
    }
}
