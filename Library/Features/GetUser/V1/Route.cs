namespace Library.Features.GetUser.V1;

public static class Route
{
    public static void MapUserEndpoint(this WebApplication app)
    {
        app.MapGet("/user/v1/{userId}", async (string userId, CancellationToken cancellationToken, Handler handler) =>
            {
                var response = await handler.Handle(userId, cancellationToken);
                return response != null ? Results.NotFound() : Results.Ok(response);
            })
            .WithName("GetUser");
    }
}