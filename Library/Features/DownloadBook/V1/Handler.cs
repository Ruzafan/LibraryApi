using Library.Features.DownloadBook.V1.Repositories;
using System.Text.Json;

namespace Library.Features.DownloadBook.V1
{
    public class Handler(HttpClient httpClient, IRepository repository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"https://openlibrary.org/search.json?q={request.Search.Replace(' ','+')}", cancellationToken);
            
            if (!response.IsSuccessStatusCode) return new Response();
            
            var responseStr = await response.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonSerializer.Deserialize<ResponseModel>(responseStr);
            if (model?.docs == null) return new Response();
                
            foreach (var item in model.docs)
            {
                if (string.IsNullOrEmpty(item.title) ||
                    item.language.Length == 0 ||
                    !item.language.Contains("spa")) continue;
                try
                {
                    await repository.AddBook(new Entities.Book(item.title)
                    {
                        Image = item.cover_i > 0
                            ? $"https://covers.openlibrary.org/w/id/{item.cover_i}-M.jpg"
                            : "",
                        Authors = item.author_name.Length != 0 ? item.author_name?.ToList() : null,
                        Pages = item.number_of_pages_median,
                        ISBN = item.isbn.Length != 0 ? item.isbn.ToList() : null,
                        Status = Entities.Status.Active,
                        People = item.person.Length != 0 ? item.person.ToList() : null,
                        Place = item.place.Length != 0 ? item.place.ToList() : null,
                        Time = item.time.Length != 0 ? item.time.ToList() : null,
                    }, cancellationToken);
                }
                catch (Exception ex)
                {
                   // logger.LogWarning("Error on reading information from request");
                }
            }

            return new Response();
        }
    }
}
