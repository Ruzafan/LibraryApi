using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetUserBookList.V1;

public static class Route
{
    public static void MapUserBookListEndpoint(this WebApplication app)
    {
        app.MapGet("/library/userbook/v1/{userId}", async ([FromRoute] string userId, CancellationToken cancellationToken, Handler handler) =>
            {
                var request = new Request() { UserId = userId };
                var response = await handler.Handle(request, cancellationToken);
                return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
            })
            .WithName("GetUserBookList");
    }
}
    
