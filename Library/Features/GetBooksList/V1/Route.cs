using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetBooksList.V1;

public static class Route
{
    public static void MapGetBookListEndpoint(this WebApplication app)
    {
        app.MapGet("/library/books/v1", async ([FromQuery] int page,[FromQuery] int rows, CancellationToken cancellationToken,  [FromServices] Handler handler) =>
            {
                var response = await handler.Handle(page,rows == 0 ? 10 : rows, cancellationToken);
                return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
            })
            .WithName("GetBooksList")
            .RequireAuthorization();
    }
}