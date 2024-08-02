using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Features.UpsertUserBook.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v1")]
    public class UpsertUserBookController : Controller
    {
        private readonly Handler _handler;
        public UpsertUserBookController(Handler handler)
        {
            _handler = handler;
        }

        [HttpPost(Name = "UpsertUserBook")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Index([FromBody] Request request, CancellationToken cancellationToken)
        {
            var response = await _handler.Handle(request, cancellationToken);
            if (response.Errors.Any())
            {
                return Problem(response.Errors.First().Value, statusCode: (int)HttpStatusCode.Conflict, title: response.Errors.First().Key);
            }
            return Ok();
        }
    }
}
