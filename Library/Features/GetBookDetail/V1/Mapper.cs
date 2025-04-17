using Library.Entities;

namespace Library.Features.GetBookDetail.V1;

public static class Mapper
{
    public static Response ToResponse(this Book bookEntity, UserBook? userBook)
        => new()
        {
            Title = bookEntity.Title,
            Image = bookEntity.Image,
            Authors = bookEntity.Authors,
            Description = bookEntity.Sinopsis,
            Genres = bookEntity.Genres,
            IsAssigned = userBook != null
        };
}