
namespace Library.Features.UpsertBook.V1
{
    public class Request{
        public string BookId { get; set; }
        public string Title { get; set; }
       // public IFormFile Image { get; set; }
        public List<string>? Authors { get; set; }
        public List<string>? Genres { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int Pages { get; set; }
    }
}