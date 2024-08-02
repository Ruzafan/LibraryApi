using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetBooksList.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v1")]
    [EnableCors()]
    public class GetBooksListController : Controller
    {
        private readonly Handler _handler;
        public GetBooksListController(Handler handler)
        {
            _handler = handler;
        }

        [HttpGet(Name = "GetBooksList")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBooksList(int page, CancellationToken cancellationToken)
        {
            var response = await _handler.Handle(page, cancellationToken);
            if (response.Books.Count == 0) { return NotFound(); }
            return Ok(response.Books);
        }
    }
}
