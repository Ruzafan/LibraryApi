// using Microsoft.AspNetCore.Mvc;
//
// namespace Library.Features.DownloadBook.V1
// {
//     [ApiController]
//     [ApiVersion("1.0")]
//     [Route("[controller]/v1")]
//     public class DownloadBookController(Handler handler) : Controller
//     {
//         [HttpPost(Name = "DownloadBook")]
//         [Consumes("application/json")]
//         [Produces("application/json")]
//         [ProducesResponseType(StatusCodes.Status201Created)]
//         public async Task<IActionResult> Index([FromBody] Request request, CancellationToken cancellationToken)
//         {
//             var response = await handler.Handle(request, cancellationToken);
//             if (response.Errors.Count != 0)
//             {
//                 return Problem();
//             }
//             return Ok();
//         }
//     }
// }
