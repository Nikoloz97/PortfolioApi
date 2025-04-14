using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace PortfolioApi.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private CloudBlobContainer _blobContainer;

        public AzureStorageService(string connectionString, string containerName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = blobClient.GetContainerReference(containerName);
        }

        public async Task<string> UploadImageAsync(string fileName, Stream imageStream)
        {
            CloudBlockBlob blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(imageStream);
            return blockBlob.Uri.ToString();
        }

        public async Task<Stream> GetImageAsync(string fileName)
        {
            CloudBlockBlob blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            MemoryStream memoryStream = new MemoryStream();
            await blockBlob.DownloadToStreamAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }

    }
}
