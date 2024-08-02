using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetUserBookDetail.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v1/{userId}/{bookId}")]
    public class GetUserBookDetailController : Controller
    {
        private readonly Handler _handler;
        public GetUserBookDetailController(Handler handler)
        {
            _handler = handler;
        }

        [HttpGet(Name = "GetUserBookDetail")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail([FromRoute] Guid userId, [FromRoute] string bookId,CancellationToken cancellationToken)
        {
            var request = new Request() { UserId = userId, BookId = bookId };
            var response = await _handler.Handle(request, cancellationToken);
            if (response.Book is null) { return NotFound(); }
            return Ok(response.Book);
        }

    }
}
