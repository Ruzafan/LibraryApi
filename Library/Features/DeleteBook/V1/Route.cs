using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.DeleteBook.V1
{
    public static class Route
    {
        public static void MapDeleteBookEndpoint(this WebApplication app)
        {
            app.MapDelete("/library/book/delete/v1", async ([FromQuery] string bookId, HttpContext httpContext, CancellationToken cancellationToken, [FromServices] Handler handler) =>
                {
                    var request = new Request();
                    request.BookId = bookId;
                    request.UserId  = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                    var response = await handler.Handle(request, cancellationToken);
                    return response.Errors.Count != 0 
                        ? Results.Problem(response.Errors.First().Value, statusCode: (int)HttpStatusCode.Conflict, title: response.Errors.First().Key) 
                        : Results.Ok();
                })
                .WithName("DeleteBook")
                .RequireAuthorization();
        }
    }
}
