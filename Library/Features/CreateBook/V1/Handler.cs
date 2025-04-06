using Azure.Storage.Blobs;
using Library.Entities;
using Library.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library.Features.CreateBook.V1
{
    public class Handler(IRepository<Book> bookRepository, IConfiguration configuration)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            await bookRepository.Add(new Book(request.Title,true)
            {
                Image = await UploadImage(request.Image),
                Status = Status.Active,
                Title = request.Title,
                Authors = request.Authors,
                Genres = request.Genres,
                Sinopsis = request.Description,
                Created = DateTime.UtcNow,
                
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
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            return $"https://readrstorage.blob.core.windows.net/images/{fileName}";
            
        }
    }
}
