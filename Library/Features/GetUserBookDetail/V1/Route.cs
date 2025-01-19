namespace Library.Features.GetUserBookDetail.V1;

public static class Route
{
    public static void MapBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/userbook/v1/{userId}/{bookId}", async (Guid userId, string bookId, CancellationToken cancellationToken, Handler handler) =>
            {
                var request = new Request() { UserId = userId, BookId = bookId };
                var response = await handler.Handle(request, cancellationToken);
                if (response.Book is null) { return Results.NotFound(); }
                return Results.Ok(response.Book);
            })
            .WithName("GetUserBookDetail");
    }
}