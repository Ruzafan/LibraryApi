using Library.Entities;

namespace Library.Features.GetBookDetail.V1;

public static class Mapper
{
    public static Response ToResponse(this Book bookEntity)
        => new()
        {
            Title = bookEntity.Title,
            Image = bookEntity.Image,
            Authors = bookEntity.Authors
        };
}