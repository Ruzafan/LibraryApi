using Microsoft.AspNetCore.Mvc;

namespace Library.Features.DownloadBook.V1;

public static class Route
{
    public static void MapDownloadBookEndpoint(this WebApplication app)
    {
        
        app.MapPost("/library/downloadbook/v1/", async ([FromBody] Request request,CancellationToken cancellationToken, Handler handler) =>
            {
                var response = await handler.Handle(request, cancellationToken);
                 return response.Errors.Count != 0 ? Results.Problem() : Results.Ok();
            })
            .WithName("DownloadBook");
    }
}