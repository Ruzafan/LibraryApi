using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetBookDetail.V1;

public static class Route
{
    public static void MapGetBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/library/book/v1/{id}", async ([FromRoute] string id, HttpContext httpContext, CancellationToken cancellationToken, [FromServices] Handler handler) =>
            {
                var userId = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                var response = await handler.Handle(new Request(){BookId = id, UserId = userId}, cancellationToken);
                return response == null ? Results.NotFound() : Results.Ok(response);
            })
            .WithName("GetBookDetail")
            .RequireAuthorization();
    }
}