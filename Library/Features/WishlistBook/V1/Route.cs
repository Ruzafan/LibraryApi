using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.WishlistBook.V1
{
    public static class Route
    {
        public static void MapWishedEndpoint(this WebApplication app)
        {
            app.MapPost("/library/wishlist/v1", async ([FromBody] Request request, HttpContext httpContext, CancellationToken cancellationToken, [FromServices] Handler handler) =>
                {
                    request.UserId  = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                    var response = await handler.Handle(request, cancellationToken);
                    return response.Errors.Count != 0 
                        ? Results.Problem(response.Errors.First().Value, statusCode: (int)HttpStatusCode.Conflict, title: response.Errors.First().Key) 
                        : Results.Ok();
                })
                .WithName("AddToWishlist")
                .RequireAuthorization();
        }
    }
}
