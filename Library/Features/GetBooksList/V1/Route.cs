namespace Library.Features.GetBooksList.V1;

public static class Route
{
    public static void MapGetListEndpoint(this WebApplication app)
    {
        app.MapGet("/bookslist/v1", async (int page, CancellationToken cancellationToken, Handler handler) =>
            {
                var response = await handler.Handle(page, cancellationToken);
                return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
            })
            .WithName("GetBooksList");
    }
}