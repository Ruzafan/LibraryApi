namespace Library.Features.GetUserBookList.V1;

public static class Route
{
    public static void MapUserBookListEndpoint(this WebApplication app)
    {
        app.MapGet("/userbook/v1/{userId}", async (Guid userId, CancellationToken cancellationToken, Handler handler) =>
            {
                var request = new Request() { UserId = userId };
                var response = await handler.Handle(request, cancellationToken);
                if (response.Books.Count == 0) { return Results.NotFound(); }
                return Results.Ok(response.Books);
            })
            .WithName("GetUserBookList");
    }
}
    
