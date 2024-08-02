using Library.Features.DownloadBook.V1.Repositories;
using MongoDB.Bson.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Library.Features.DownloadBook.V1
{
    public class Handler
    {
        private readonly IRepository _repository;
        private readonly HttpClient _httpClient;
        public Handler(HttpClient httpClient, IRepository repository)
        {
            _repository = repository;
            _httpClient = httpClient;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {

            var response = await _httpClient.GetAsync($"https://openlibrary.org/search.json?q={request.Search.Replace(' ','+')}");
            if(response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<ResponseModel>(responseStr);
                foreach( var item in model.docs )
                {
                    if(item is not null &&
                       !string.IsNullOrEmpty(item.title) &&
                       item.language is not null &&
                       item.language.Any() &&
                       item.language.Contains("spa"))
                    {
                        await _repository.AddBook(new Entities.Book(item.title)
                        {
                            Image = item.cover_i > 0 ? $"https://covers.openlibrary.org/w/id/{item.cover_i}-M.jpg" : "",
                            Authors = item.author_name?.ToList(),
                            Pages = item.number_of_pages_median,
                            ISBN = item.isbn?.ToList(),
                            Status = Entities.Status.Active,
                            People = item.person?.ToList(),
                            Place = item.place?.ToList(),
                            Time = item.time?.ToList(),

                        }, cancellationToken);
                    }
                    
                }
                
            }
            
            return new Response();
        }
    }
}
