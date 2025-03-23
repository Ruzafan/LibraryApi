namespace Library.Entities
{
    public class User : Mongeable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public List<string> FriendsIds { get; set; }
        public DateTime Created { get; set; }
    }
}
