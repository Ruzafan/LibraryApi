using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetBookDetail.V1;

public static class Route
{
    public static void MapGetBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/library/book/v1/{id}", async ([FromRoute] string id, CancellationToken cancellationToken, [FromServices] Handler handler) =>
            {
                var response = await handler.Handle(new Request(){BookId = id}, cancellationToken);
                return response == null ? Results.NotFound() : Results.Ok(response);
            })
            .WithName("GetBookDetail")
            .RequireAuthorization();
    }
}