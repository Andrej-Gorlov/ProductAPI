namespace ProductAPI.Service.Interfaces
{
    public interface IImageAccessorService
    {
        Task<ImageUpload?> AddImageAsync(IFormFile file, string? id = null);
        Task<bool> DeleteImageAsync(string publicId);
    }
}
