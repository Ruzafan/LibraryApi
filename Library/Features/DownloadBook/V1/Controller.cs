using Microsoft.AspNetCore.Mvc;

namespace Library.Features.DownloadBook.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]/v1")]
    public class DownloadBookController : Controller
    {
        private readonly Handler _handler;
        public DownloadBookController(Handler handler)
        {
            _handler = handler;
        }

        [HttpPost(Name = "DownloadBook")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Index([FromBody] Request request, CancellationToken cancellationToken)
        {
            var response = await _handler.Handle(request, cancellationToken);
            if (response.Errors.Any())
            {
                return Problem();
            }
            return Ok();
        }
    }
}
