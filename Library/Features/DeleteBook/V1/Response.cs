namespace Library.Features.DeleteBook.V1;

public class Response
{
    public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();

    public Response AddError(string errorKey, string errorValue)
    {
        if (Errors.ContainsKey(errorKey))
        {
            Errors[errorKey] = errorValue;
        }
        else
        {
            Errors.Add(errorKey, errorValue);
        }
        return this;
    }
}