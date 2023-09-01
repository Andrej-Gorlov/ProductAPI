namespace ProductAPI.Service.Helpers
{
    public interface ICloudinaryActions
    {
        Task<Image?> AddImageAsync(IFormFile file, int ProductId);
        Task<IList<Image>?> AddImagesAsync(IList<IFormFile> files, int ProductId);
        Task<Image?> UpdateImageAsync(IFormFile file, int ProductId, string ImageId);
        Task<IList<Image>?> UpdateImagesAsync(IList<IFormFile> files, int ProductId, IList<string> ImagesId);
        Task<bool> DeleteImageAsync(string imageId);
    }
    public class CloudinaryActions: ICloudinaryActions
    {
        private readonly IImageAccessorService _imageAccessorSer;
        private readonly ILogger<CloudinaryActions> _logger;
        public CloudinaryActions(IImageAccessorService imageAccessorSer, ILogger<CloudinaryActions> logger)
        {
            _imageAccessorSer= imageAccessorSer;
            _logger= logger;
        }

        #region Add image(s)
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<Image?> AddImageAsync(IFormFile file, int ProductId)
        {
            if (file.Length > 0)
            {
                _logger.LogInformation("Добавление изображения (IImageAccessorService).");
                var image = await _imageAccessorSer.AddImageAsync(file);
                if (image is null)
                {
                    _logger.LogInformation("Изображение не добавлено.");
                }
                else
                {
                    _logger.LogInformation("Изображение добавлено.");
                    return new()
                    {
                        ImageId = image.PublicId,
                        ProductId = ProductId,
                        ImageUrl = image.Url,
                    };
                }
            }
            return null;
        }
        /// <summary>
        /// Add list image
        /// </summary>
        /// <param name="files"></param>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public async Task<IList<Image>?> AddImagesAsync(IList<IFormFile> files, int ProductId)
        {
            if (files.Count > 0)
            {
                _logger.LogInformation("Добавление изображения (IImageAccessorService).");
                var images = new ConcurrentBag<Image>();
                foreach (var file in files)
                {
                    var image = await _imageAccessorSer.AddImageAsync(file);
                    if (image is null)
                    {
                        _logger.LogInformation("Список изображений не добавлен.");
                        return null;
                    }
                    images.Add(new()
                    {
                        ImageId = image.PublicId,
                        ProductId = ProductId,
                        ImageUrl = image.Url
                    });
                }
                _logger.LogInformation("Список изображений добавлен.");
                return images.ToList();
            }
            return null;
        }
        #endregion

        #region Update image(s)
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="file"></param>
        /// <param name="ProductId"></param>
        /// <param name="idImage"></param>
        /// <param name="isMain"></param>
        /// <returns></returns>
        public async Task<Image?> UpdateImageAsync(IFormFile file, int ProductId, string ImageId)
        {
            if (file.Length > 0)
            {
                _logger.LogInformation("Обнавление изображения (IImageAccessorService).");
                var image = await _imageAccessorSer.AddImageAsync(file, ImageId);
                if (image is null)
                {
                    _logger.LogInformation("Изображение не обновлено.");
                }
                else
                {
                    _logger.LogInformation("Изображение обновлено.");
                    return new()
                    {
                        ImageId = image.PublicId,
                        ProductId = ProductId,
                        ImageUrl = image.Url,
                    };
                }
            }
            return null;
        }
        /// <summary>
        /// Update list image
        /// </summary>
        /// <param name="files"></param>
        /// <param name="ProductId"></param>
        /// <param name="ImagesId"></param>
        /// <returns></returns>
        public async Task<IList<Image>?> UpdateImagesAsync(IList<IFormFile> files, int ProductId, IList<string> ImagesId)
        {
            if (files.Count > 0 && ImagesId.Count > 0)
            {
                _logger.LogInformation("Обнавление изображения (IImageAccessorService).");
                var images = new ConcurrentBag<Image>();
                for (int i = 0; i < files.Count; i++)
                {
                    var image = await _imageAccessorSer.AddImageAsync(files[i], ImagesId[i]);
                    if (image is null)
                    {
                        _logger.LogInformation("Список изображений не обнавлён.");
                        return null;
                    }
                    images.Add(new()
                    {
                        ImageId = image.PublicId,
                        ProductId = ProductId,
                        ImageUrl = image.Url
                    });
                }
                _logger.LogInformation("Список изображений обнавлён.");
                return images.ToList();
            }
            return null;
        }
        #endregion

        #region Delete image
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteImageAsync(string imageId)
        {
            var result = await _imageAccessorSer.DeleteImageAsync(imageId);
            if (result) _logger.LogInformation("Изображение продукта удаленно.");
            else _logger.LogInformation("Изображение продукта не удаленно.");
            return result;
        }
        #endregion
    }
}
