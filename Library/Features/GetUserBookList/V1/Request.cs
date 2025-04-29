using Library.Entities;

namespace Library.Features.GetUserBookList.V1
{
    public class Request
    {
        public string UserId { get; set; }
        public bool WishList { get; set; }
    }
}
