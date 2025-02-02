using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Features.UpsertUserBook.V1
{
    public static class Route
    {
        public static void MapUpsertUserBookEndpoint(this WebApplication app)
        {
            app.MapPost("/library/userbook/v1", async ([FromBody] Request request, CancellationToken cancellationToken, [FromServices] Handler handler) =>
                {
                    var response = await handler.Handle(request, cancellationToken);
                    return response.Errors.Count != 0 
                        ? Results.Problem(response.Errors.First().Value, statusCode: (int)HttpStatusCode.Conflict, title: response.Errors.First().Key) 
                        : Results.Ok();
                })
                .WithName("UpsertUserBook");
        }
    }
}
