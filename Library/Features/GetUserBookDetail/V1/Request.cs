namespace Library.Features.GetUserBookDetail.V1
{
    public class Request
    {
        public Guid UserId { get; set; }
        public string BookId { get; set; }
    }
}
