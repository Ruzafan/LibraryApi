namespace Library.Features.GetUserBookList.V1
{
    public class BookResponse
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Image { get; set; }
        public required List<string>? Genres { get; set; }
    }
}
