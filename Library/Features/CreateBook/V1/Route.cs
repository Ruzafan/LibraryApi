namespace Library.Features.CreateBook.V1
{
    public static class Route
    {
        public static void MapCreateBookEndpoint(this WebApplication app)
        {
            app.MapPost("/library/book/create/v1", async (HttpRequest request, CancellationToken cancellationToken, Handler handler) =>
                {
                    var form = await request.ReadFormAsync(cancellationToken);
                    var handlerRequest = new Request
                    {
                        Title = form["title"].ToString(),
                        Authors = [form["author"].ToString()],
                        Genres = form["genres"].ToString().Split(",").ToList(),
                        Description = form["description"].ToString()
                    };

                    var file = form.Files["image"];
                    if (file == null || file.Length == 0)
                        return Results.BadRequest("Image is required.");
                    handlerRequest.Image = file;
                    var response = await handler.Handle(handlerRequest, cancellationToken);
                    return response.Errors != null && response.Errors.Count != 0 ? Results.Problem() : Results.Ok();
                })
                .WithName("CreateBook")
                .RequireAuthorization();
        }
    }
}
