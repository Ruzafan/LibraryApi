using Azure.Storage.Blobs;
using Library.Entities;
using Library.Repositories;
using MongoDB.Driver;

namespace Library.Features.UpsertBook.V1
{
    public class Handler(IRepository<Book> bookRepository, IConfiguration configuration)
    {
        public async Task<Response> Handle(Request request, CancellationToken cancellationToken = default)
        {
            var book = await bookRepository.Get(request.BookId, cancellationToken);
            if (book == null) return new Response();
            var bookBuilder = Builders<Book>.Update.Combine(
                Builders<Book>.Update.Set(x => x.Authors, request.Authors != null && request.Authors.Any() ? request.Authors : book.Authors),
                //Builders<Book>.Update.Set(x => x.Image, request.Image != null ? await UploadImage(request.Image) : book.Image),
                Builders<Book>.Update.Set(x => x.Pages, request.Pages != 0 ? request.Pages : book.Pages),
                Builders<Book>.Update.Set(x => x.Genres, request.Genres != null && request.Genres.Any()? request.Genres : book.Genres),
                Builders<Book>.Update.Set(x => x.Sinopsis, !string.IsNullOrEmpty(request.Description)? request.Description : book.Sinopsis),
                Builders<Book>.Update.Set(x => x.Updated, DateTime.Now)
            );
            await bookRepository.Update(book.Id, bookBuilder, cancellationToken);
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
