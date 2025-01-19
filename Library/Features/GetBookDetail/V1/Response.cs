namespace Library.Features.GetBookDetail.V1;

public class Response
{
    public required string Title { get; set; }
    public required string Image { get; set; }
    public List<string>? Authors { get; set; }
}