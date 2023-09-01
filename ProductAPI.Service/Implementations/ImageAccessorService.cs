using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using ProductAPI.Domain;

namespace ProductAPI.Service.Implementations
{
    public class ImageAccessorService : IImageAccessorService
    {
        private readonly Cloudinary _cloudinary;
        public ImageAccessorService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }
        /// <summary>
        /// Add or Update
        /// </summary>
        /// <param name="file"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ImageUpload?> AddImageAsync(IFormFile file, string? id = null)
        {
            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream)
            };
            if (id != null) uploadParams.PublicId = id;

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);//.ConfigureAwait(false);
            if (uploadResult.Error != null)
            {
                throw new Exception(uploadResult.Error.Message);
            }
            return new ImageUpload
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString()
            };
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);//.ConfigureAwait(false);
            return result.Result == "ok" ? true : false;
        }
    }
}
