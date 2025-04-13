namespace Library.Features.GetBooksList.V1
{
    public class BookResponse
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
        public bool Wished { get; set; }
    }
}
