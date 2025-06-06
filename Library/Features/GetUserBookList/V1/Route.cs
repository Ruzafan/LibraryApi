﻿using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Library.Features.GetUserBookList.V1;

public static class Route
{
    public static void MapUserBookListEndpoint(this WebApplication app)
    {
        app.MapGet("/library/userbook/v1/", async ([FromQuery] bool wishlist, [FromQuery] string? friendId, HttpContext httpContext, CancellationToken cancellationToken, Handler handler) =>
            {
                var userId = httpContext.User.Claims.First(q=> q.Type == ClaimTypes.Name).Value;
                var request = new Request() { UserId = string.IsNullOrEmpty(friendId) ? userId : friendId, WishList=wishlist };
                var response = await handler.Handle(request, cancellationToken);
                return response.Books.Count == 0 ? Results.NotFound() : Results.Ok(response.Books);
            })
            .WithName("GetUserBookList")
            .RequireAuthorization();
    }
}
    
