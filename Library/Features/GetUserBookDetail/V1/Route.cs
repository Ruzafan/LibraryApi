namespace Library.Features.GetUserBookDetail.V1;

public static class Route
{
    public static void MapUserBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/userbook/v1/{userId}/{bookId}", async (Guid userId, string bookId, CancellationToken cancellationToken, Handler handler) =>
            {
                var request = new Request() { UserId = userId, BookId = bookId };
                var response = await handler.Handle(request, cancellationToken);
                return response.Book is null 
                    ? Results.NotFound() 
                    : Results.Ok(response.Book);
            })
            .WithName("GetUserBookDetail");
    }
}