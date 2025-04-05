using Azure.Storage.Blobs;
using Library.Entities;
using Library.Repositories;

namespace Library.Features.CreateBook.V1
{
    public class Handler(IRepository<Book> bookRepository, IConfiguration configuration)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            await bookRepository.Add(new Book(request.Title)
            {
                Image = await UploadImage(request.Image),
                Status = Status.Active,
                Title = request.Title,
                Authors = request.Authors,
                Genres = request.Genres,
                Sinopsis = request.Description
                
            }, cancellationToken);
            return new Response();
        }

        private async Task<string> UploadImage(IFormFile file)
        {
            var storageConnectionString = configuration["AzureBlob_ConnectionString"];
            var containerName = Constants.ImagesBlobContainer;

            var blobServiceClient = new BlobServiceClient(storageConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            var blobClient = containerClient.GetBlobClient(Guid.NewGuid() + "_" + file.FileName);
            await using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            return blobClient.Uri.ToString();
            
        }
    }
}
