using ProductAPI.Service.Helpers;

namespace ProductAPI.Service.Implementations
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRep;
        private IMapper _mapper;
        private BaseResponse<ImageDTO> baseResponse;
        private string message = "";
        public ImageService(IImageRepository imageRep, IMapper mapper)
        {
            _imageRep = imageRep;
            _mapper = mapper;
            baseResponse = new();
        }
        /// <summary>
        /// Сохранение изображения.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> CreateServiceAsync(CreateImageDTO createModel)
        {
            WatchLogger.Log($"Сохранение изображения. / method: CreateServiceAsync");
            if (await _imageRep.GetByAsync(x => x.ImageUrl == createModel.ImageUrl) != null)
            {
                WatchLogger.Log("Изображение с таким url существует.");
                baseResponse.DisplayMessage = "Изображение с таким url существует.";
                baseResponse.Status = Status.ExistsUrl;
                return baseResponse;
            }
            var image = await _imageRep.CreateAsync(_mapper.Map<Image>(createModel));
            if (image != null)
            {
                WatchLogger.Log("Изображение сохранено.");
            }
            else
            {
                WatchLogger.Log("Изображение не сохранено.");
                baseResponse.DisplayMessage = "Изображение не сохранено.";
                baseResponse.Status = Status.NotCreate;
            }
            baseResponse.Result = _mapper.Map<ImageDTO>(image);
            return baseResponse;
        }
        /// <summary>
        /// Удаление изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            WatchLogger.Log($"Удаление изображения. / method: DeleteServiceAsync");
            var bResponse = new BaseResponse<bool>();
            WatchLogger.Log($"Поиск изображения по id: {id}. / method: DeleteServiceAsync");
            Image image = await _imageRep.GetByAsync(x => x.ImageId == id, true);
            if (image is null)
            {
                WatchLogger.Log($"Изображение c id: {id} не найдено.");
                baseResponse.DisplayMessage = $"Изображение c id: {id} не найдено.";
                bResponse.Result = false;
                WatchLogger.Log($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return bResponse;
            }
            await _imageRep.DeleteAsync(image);
            baseResponse.DisplayMessage = "Изображение удалено.";
            bResponse.Result = true;
            WatchLogger.Log($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return bResponse;
        }
        /// <summary>
        /// Вывод изображения
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ImageDTO>> GetByIdServiceAsync(int id)
        {
            WatchLogger.Log($"Поиск изображения по id: {id}. / method: GetByIdServiceAsync");
            Image image = await _imageRep.GetByAsync(x => x.ImageId == id);
            if (image is null)
            {
                WatchLogger.Log($"Изображение под id [{id}] не найдено");
                baseResponse.DisplayMessage = $"Изображение под id [{id}] не найдено";
                baseResponse.Status = Status.NotFound;
            }
            else
            {
                WatchLogger.Log($"Вывод изображения по id [{id}]");
            }
            baseResponse.Result = _mapper.Map<ImageDTO>(image);
            WatchLogger.Log($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Список изображений (возможно приминение поиска)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<List<ImageDTO>>> GetServiceAsync(string? filter = null, string? search = null)
        {
            WatchLogger.Log($"Список изображений. / method: GetServiceAsync");
            var bResponse = new BaseResponse<List<ImageDTO>>();
            IEnumerable<Image>? images = null;
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(images, filter, search);
                images = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (!string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(images, filter);
                images = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                images = await _imageRep.GetAsync(search: search);
            }
            if (images is null)
            {
                WatchLogger.Log("Список изображения пуст.");
                baseResponse.DisplayMessage = "Список изображения пуст.";
            }
            else
            {
                WatchLogger.Log("Список изображения.");
                IEnumerable<ImageDTO> listImages = _mapper.Map<IEnumerable<ImageDTO>>(images);
                bResponse.Result = listImages.ToList();
            }
            WatchLogger.Log($"Ответ отправлен контролеру/ method: GetServiceAsync");
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
            WatchLogger.Log($"Обновление изображения.");
            var carent = await _imageRep.GetByAsync(x => x.ImageId == updateModel.ImageId, false);
            if (carent is null)
            {
                WatchLogger.Log("Попытка обновить объект, которого нет в хранилище.");
                baseResponse.Status = Status.NotFound;
                baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var image = await _imageRep.UpdateAsync(_mapper.Map<Image>(updateModel), carent); ;
                baseResponse.DisplayMessage = "Изображение обновилось.";
                baseResponse.Result = _mapper.Map<ImageDTO>(image);
            }
            WatchLogger.Log($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Фильтр и поиск изображения по значению
        /// </summary>
        /// <param name="categorys"></param>
        /// <param name="idProduct"></param>
        /// <returns>Отфильтрованный список и сообщение</returns>
        private async Task<(IEnumerable<Image>?, string)> FilterAndSearchAsync(IEnumerable<Image>? images, string filter, string? search = null)
        {
            WatchLogger.Log($"Поиск изображения по id категории: {filter}. / method: FilterAsync");
            int idProduct;
            Uri? uri;
            if (Int32.TryParse(filter.ToString(), out idProduct))
            {
                images = await _imageRep.GetAsync(x => x.ProductId == idProduct, search);

                if (images is null)
                    message = Message.FilterAndSearch(true, "изображений", filter, search);
                else
                    message = Message.FilterAndSearch(false, "изображений", filter, search);
            }
            if (Uri.TryCreate(filter, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                images = await _imageRep.GetAsync(x => x.ImageUrl == uri.ToString(), search);

                if (images is null)
                    message = Message.FilterAndSearch(true, "изображений", filter, search);
                else
                    message = Message.FilterAndSearch(false, "изображений", filter, search);
            }
            WatchLogger.Log($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
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
