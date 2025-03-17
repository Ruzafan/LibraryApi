using System.Security.Claims;

namespace Library.Features.GetUserBookDetail.V1;

public static class Route
{
    public static void MapUserBookDetailEndpoint(this WebApplication app)
    {
        app.MapGet("/library/userbook/v1/{bookId}", async (HttpContext httpContext, string bookId, CancellationToken cancellationToken, Handler handler) =>
            {
                var userId = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                var request = new Request() { UserId = userId, BookId = bookId };
                var response = await handler.Handle(request, cancellationToken);
                return response.Book is null 
                    ? Results.NotFound() 
                    : Results.Ok(response.Book);
            })
            .WithName("GetUserBookDetail")
            .RequireAuthorization();
    }
}