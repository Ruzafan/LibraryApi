using Microsoft.AspNetCore.Mvc;

namespace Library.Features.UpsertBook.V1
{
    public static class Route
    {
        public static void MapUpsertBookEndpoint(this WebApplication app)
        {
            app.MapPost("/library/book/v1", async ([FromBody] Request request, CancellationToken cancellationToken, Handler handler) =>
                {
                    var response = await handler.Handle(request, cancellationToken);
                    return response.Errors.Count != 0 ? Results.Problem() : Results.Ok();
                })
                .WithName("UpserBookEndpoint");
        }
    }
}
