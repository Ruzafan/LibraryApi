namespace Library.Entities
{
    public class User : Mongeable
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
