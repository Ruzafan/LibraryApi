namespace Library.Features.GetBookDetail.V1;

public static class Route
{
    public static void MapGetBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/getbook/v1/{id}", async (string id, CancellationToken cancellationToken, Handler handler) =>
            {
                var response = await handler.Handle(new Request(){BookId = id}, cancellationToken);
                return response == null ? Results.NotFound() : Results.Ok(response);
            })
            .WithName("GetBooksList");
    }
}