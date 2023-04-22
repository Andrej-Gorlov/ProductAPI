namespace ProductAPI.Service.Implementations
{
    public class ImageService : BaseService<ImageService, ImageDTO>, IImageService
    {
        private IImageRepository _imageRep;
        public ImageService(IImageRepository imageRep, IMapper mapper, ILogger<ImageService> logger):base(mapper, logger,new()) => _imageRep = imageRep;

        /// <summary>
        /// Сохранение изображения.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> CreateServiceAsync(CreateImageDTO createModel)
        {
            _logger.LogInformation($"Сохранение изображения. / method: CreateServiceAsync");
            if (await _imageRep.GetByAsync(x => x.ImageUrl == createModel.ImageUrl) != null)
            {
                _logger.LogWarning("Изображение с таким url существует.");
                _baseResponse.DisplayMessage = "Изображение с таким url существует.";
                _baseResponse.Status = Status.ExistsUrl;
                return _baseResponse;
            }
            var image = await _imageRep.CreateAsync(_mapper.Map<Image>(createModel));
            if (image != null)
            {
                _logger.LogInformation("Изображение сохранено.");
            }
            else
            {
                _logger.LogWarning("Изображение не сохранено.");
                _baseResponse.DisplayMessage = "Изображение не сохранено.";
                _baseResponse.Status = Status.NotCreate;
            }
            _baseResponse.Result = _mapper.Map<ImageDTO>(image);
            return _baseResponse;
        }
        /// <summary>
        /// Удаление изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
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
            await _imageRep.DeleteAsync(image);
            _baseResponse.DisplayMessage = "Изображение удалено.";
            bResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return bResponse;
        }
        /// <summary>
        /// Вывод изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> GetByIdServiceAsync(int id)
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
                var image = await _imageRep.UpdateAsync(_mapper.Map<Image>(updateModel), carent); ;
                _baseResponse.DisplayMessage = "Изображение обновилось.";
                _baseResponse.Result = _mapper.Map<ImageDTO>(image);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return _baseResponse;
        }
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

        /// <summary>
        /// Поиск изображения по значению 
        /// </summary>
        /// <param name="images"></param>
        /// <param name="search"></param>
        /// <returns>Искомые изображении и сообщение</returns>
        //private async Task<(IEnumerable<Image>?, string)> SearchAsync(IEnumerable<Image>? images, string search)
        //{
        //    WatchLogger.Log($"Поиск изображения по: {search}. / method: SearchAsync");
        //    await Task.Factory.StartNew(() =>
        //    {
        //        images = images.Where(
        //            x => EF.Functions.Like(x.ImageUrl.ToUpper(), $"%{search.ToUpper()}%"));
        //    });
        //    if (images.Count() is 0)
        //    {
        //        WatchLogger.Log(message + $"\n по поиску: {search} не чего не найдено.");
        //        message += $"\n по поиску: {search} не чего не найдено.";
        //    }
        //    else
        //    {
        //        WatchLogger.Log(message + $"\n по попоиску: {search}");
        //        message += $"\n по попоиску: {search}";
        //    }
        //    WatchLogger.Log($"Ответ отправлен GetServiceAsync/ method: SearchAsync");
        //    return (images, message);
        //}
    }
}
