using System.Text.Json;
using Library.Entities;
using Library.Repositories;

namespace Library.Features.DownloadBook.V1
{
    
    public class Handler(HttpClient httpClient, IRepository<Book> repository)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var response = await httpClient.GetAsync($"https://openlibrary.org/search.json?q={request.Search.Replace(' ','+')}&fields=author_name,cover_i,title,language,key", cancellationToken);
            
            if (!response.IsSuccessStatusCode) return new Response();
            
            var responseStr = await response.Content.ReadAsStringAsync(cancellationToken);
            var model = JsonSerializer.Deserialize<ResponseModel>(responseStr);
            if (model?.docs == null) return new Response();
                
            foreach (var item in model.docs)
            {
                if (string.IsNullOrEmpty(item.title) ||
                    item.language?.Length == 0 ||
                    item.cover_i == 0) continue;
                try
                {
                    Thread.Sleep(1000);
                    var responseWork = await httpClient.GetAsync($"https://openlibrary.org/{item.key}.json", cancellationToken);
                    if (!responseWork.IsSuccessStatusCode) continue;
            
                    var responseWorkStr = await responseWork.Content.ReadAsStringAsync(cancellationToken);
                    var modelWorkResponse = JsonSerializer.Deserialize<WorkResponse>(responseWorkStr);
                    await repository.Add(new Book(item.title, true)
                    {
                        Image = item.cover_i > 0
                            ? $"https://covers.openlibrary.org/w/id/{item.cover_i}-M.jpg"
                            : "",
                        Authors = item.author_name.Length != 0
                            ? item.author_name?.ToList()
                            : null,
                        Sinopsis = modelWorkResponse!.description,
                        Genres = modelWorkResponse!.subjects?.Intersect(Constants.PossibleGenres).ToList(),
                        Status = Status.Active,
                        Rating = item.ratings_average


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
