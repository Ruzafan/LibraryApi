using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.UpsertBook.V1
{
    public static class Route
    {
        public static void MapUpsertBookEndpoint(this WebApplication app)
        {
            app.MapPatch("/library/book/v1", async ([FromBody] Request request, HttpContext httpContext, CancellationToken cancellationToken, Handler handler) =>
                {
                    request.UserId = httpContext.User.Claims.First(q => q.Type == ClaimTypes.Name).Value;
                    var response = await handler.Handle(request, cancellationToken);
                    return response.Errors.Count != 0 ? Results.Problem() : Results.Ok();
                })
                .WithName("UpsertBook")
                .RequireAuthorization();
        }
    }
}
