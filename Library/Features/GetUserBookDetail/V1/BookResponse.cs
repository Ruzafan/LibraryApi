namespace Library.Features.GetUserBookDetail.V1
{
    public class BookResponse
    {
        public required string BookId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Rating { get; set; }
        public string? Comments { get; set; }
    }
}
