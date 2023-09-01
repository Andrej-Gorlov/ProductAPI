namespace ProductAPI.Service.Implementations
{
    public class ImageService : BaseService<ImageService, ImageDTO>, IImageService
    {
        private readonly IImageRepository _imageRep;
        private readonly ICloudinaryActions _cloudinary;
        public ImageService(IImageRepository imageRep, ICloudinaryActions cloudinary,
            IMapper mapper, ILogger<ImageService> logger):base(mapper, logger, new())
        {
            _imageRep = imageRep;
            _cloudinary = cloudinary;
        }

        #region Create
        /// <summary>
        /// Сохранение изображения.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> CreateServiceAsync(CreateImageDTO createModel)
        {
            _logger.LogInformation($"Сохранение изображения. / method: CreateServiceAsync");

            var image = _mapper.Map<Image>(createModel);
            image = await _cloudinary.AddImageAsync(createModel.FileImage!, image.ProductId);

            var imageRep = await _imageRep.CreateAsync(image!);
            if (imageRep != null)
            {
                _logger.LogInformation("Изображение сохранено.");
            }
            else
            {
                _logger.LogWarning("Изображение не сохранено.");
                _baseResponse.DisplayMessage = "Изображение не сохранено.";
                _baseResponse.Status = Status.NotCreate;
            }
            _baseResponse.Result = _mapper.Map<ImageDTO>(imageRep);
            return _baseResponse;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(string id)
        {
            _logger.LogInformation($"Удаление изображения. / method: DeleteServiceAsync");
            var bResponse = new BaseResponse<bool>();
            _logger.LogInformation($"Поиск изображения по id: {id}. / method: DeleteServiceAsync");
            Image image = await _imageRep.GetByAsync(x => x.ImageId == id, true);
            if (image is null)
            {
                _logger.LogWarning($"Изображение c id: {id} не найдено.");
                _baseResponse.DisplayMessage = $"Изображение c id: {id} не найдено.";
                bResponse.Result = false;
                _logger.LogInformation($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return bResponse;
            }
            if (!await _cloudinary.DeleteImageAsync(image.ImageId))
            {
                _logger.LogWarning($"Изображение c id: {image.ImageId} в сloudinary не найдено.");
                _baseResponse.DisplayMessage = $"Изображение c id: {image.ImageId} в сloudinary не найдено.";
                bResponse.Result = false;
                _logger.LogInformation($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return bResponse;
            }
            await _imageRep.DeleteAsync(image);
            _baseResponse.DisplayMessage = "Изображение удалено.";
            bResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return bResponse;
        }
        #endregion

        #region GetById
        /// <summary>
        /// Вывод изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> GetByIdServiceAsync(string id)
        {
            _logger.LogInformation($"Поиск изображения по id: {id}. / method: GetByIdServiceAsync");
            Image image = await _imageRep.GetByAsync(x => x.ImageId == id);
            if (image is null)
            {
                _logger.LogWarning($"Изображение под id [{id}] не найдено");
                _baseResponse.DisplayMessage = $"Изображение под id [{id}] не найдено";
                _baseResponse.Status = Status.NotFound;
            }
            else
            {
                _logger.LogInformation($"Вывод изображения по id [{id}]");
            }
            _baseResponse.Result = _mapper.Map<ImageDTO>(image);
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return _baseResponse;
        }
        #endregion

        #region Get
        /// <summary>
        /// Список изображений (возможно приминение поиска)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<List<ImageDTO>>> GetServiceAsync(string? filter = null, string? search = null)
        {
            _logger.LogInformation($"Список изображений. / method: GetServiceAsync");
            var bResponse = new BaseResponse<List<ImageDTO>>();
            IEnumerable<Image>? images = null;
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(images, filter, search);
                images = result.Item1;
                _baseResponse.DisplayMessage = result.Item2;
            }
            if (!string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(images, filter);
                images = result.Item1;
                _baseResponse.DisplayMessage = result.Item2;
            }
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                images = await _imageRep.GetAsync(search: search);
            }
            if (images is null)
            {
                _logger.LogWarning("Список изображения пуст.");
                _baseResponse.DisplayMessage = "Список изображения пуст.";
            }
            else
            {
                _logger.LogInformation("Список изображения.");
                IEnumerable<ImageDTO> listImages = _mapper.Map<IEnumerable<ImageDTO>>(images);
                bResponse.Result = listImages.ToList();
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetServiceAsync");
            return bResponse;
        }
        #endregion

        #region Update
        /// <summary>
        /// Обновление изображения.
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<ImageDTO>> UpdateServiceAsync(UpdateImageDTO updateModel)
        {
            _logger.LogInformation($"Обновление изображения.");
            var carent = await _imageRep.GetByAsync(x => x.ImageId == updateModel.ImageId, false);
            if (carent is null)
            {
                _logger.LogWarning("Попытка обновить объект, которого нет в хранилище.");
                _baseResponse.Status = Status.NotFound;
                _baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var image = _mapper.Map<Image>(updateModel);
                if (image.ImageUrl is null)
                {
                    image = await _cloudinary.AddImageAsync(updateModel.FileImage!, image.ProductId);
                }
                else
                {
                    image = await _cloudinary.UpdateImageAsync(updateModel.FileImage!, image.ProductId, updateModel.ImageId!);
                }
                var imageRep = await _imageRep.UpdateAsync(image!, carent); ;
                _baseResponse.DisplayMessage = "Изображение обновилось.";
                _baseResponse.Result = _mapper.Map<ImageDTO>(imageRep);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return _baseResponse;
        }
        #endregion

        #region Filter
        /// <summary>
        /// Фильтр и поиск изображения по значению
        /// </summary>
        /// <param name="categorys"></param>
        /// <param name="idProduct"></param>
        /// <returns>Отфильтрованный список и сообщение</returns>
        private async Task<(IEnumerable<Image>?, string)> FilterAndSearchAsync(IEnumerable<Image>? images, string filter, string? search = null)
        {
            _logger.LogInformation($"Поиск изображения по id категории: {filter}. / method: FilterAsync");
            int idProduct;
            Uri? uri;
            if (Int32.TryParse(filter.ToString(), out idProduct))
            {
                images = await _imageRep.GetAsync(x => x.ProductId == idProduct, search);

                if (images is null)
                    message = Message.FilterAndSearch(_logger, true, "изображений", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "изображений", filter, search);
            }
            if (Uri.TryCreate(filter, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                images = await _imageRep.GetAsync(x => x.ImageUrl == uri.ToString(), search);

                if (images is null)
                    message = Message.FilterAndSearch(_logger, true, "изображений", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "изображений", filter, search);
            }
            _logger.LogInformation($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
            return (images, message);
        }
        #endregion
    }
}
