
namespace Library.Features.CreateBook.V1
{
    public class Request{
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public List<string>? Authors { get; set; }
        public List<string> Genres { get; set; }
        public string Description { get; set; }
    }
}