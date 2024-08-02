using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetUserBooksList.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v1/{userId}")]
    public class GetUserBooksListController : Controller
    {
        private readonly Handler _handler;
        public GetUserBooksListController(Handler handler)
        {
            _handler = handler;
        }

        [HttpGet(Name = "GetUserBooksList")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        public async Task<IActionResult> GetList([FromRoute] Guid userId, CancellationToken cancellationToken)
        {
            var request = new Request() { UserId = userId };
            var response = await _handler.Handle(request, cancellationToken);
            if (response.Books.Count == 0) { return NotFound(); }
            return Ok(response.Books);
        }

    }
}
