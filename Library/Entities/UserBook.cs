﻿namespace Library.Entities
{
    public class UserBook : Auditable
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public decimal Rating { get; set; }
        public string? Comments { get; set; }
        public List<string>? Genres { get; set; }
        public StatusType StatusType { get; set; }
    }
}
