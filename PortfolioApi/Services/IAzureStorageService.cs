namespace PortfolioApi.Services
{
    public interface IAzureStorageService
    {
        Task<string> UploadImageAsync(string fileName, Stream imageStream);
        Task<Stream> GetImageAsync(string fileName);
    }
}
