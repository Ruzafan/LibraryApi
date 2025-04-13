using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetBooksList.V1;

public static class Route
{
    public static void MapGetBookListEndpoint(this WebApplication app)
    {
        app.MapGet("/library/books/v1", async (HttpContext httpContext, [FromQuery] string filter, [FromQuery] int page,[FromQuery] int rows, CancellationToken cancellationToken,  [FromServices] Handler handler) =>
            {
                var userId = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                var response = await handler.Handle(filter,page,rows == 0 ? 10 : rows, userId, cancellationToken);
                return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
            })
            .WithName("GetBooksList")
            .RequireAuthorization();
    }
}