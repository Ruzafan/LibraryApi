namespace Library.Features.GetBookDetail.V1;

public class Response
{
    public required string Title { get; set; }
    public required string Image { get; set; }
    public List<string>? Authors { get; set; }
    public required string Description { get; set; }
    public List<string>? Genres { get; set; }
    public bool IsAssigned { get; set; }
    public int Pages { get; set; }
}