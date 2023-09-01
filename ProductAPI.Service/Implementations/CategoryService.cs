namespace ProductAPI.Service.Implementations
{
    public class CategoryService : BaseService<CategoryService, CategoryDTO>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRep;
        private readonly IImageAccessorService _imageAccessorSer;
        public CategoryService(ICategoryRepository categoryRep, IImageAccessorService imageAccessorSer, IMapper mapper, ILogger<CategoryService> logger) 
            : base(mapper, logger, new()) 
        {
            _categoryRep = categoryRep;
            _imageAccessorSer = imageAccessorSer;
        }

        #region Create
        /// <summary>
        /// Создание категории.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<CategoryDTO>> CreateServiceAsync(CreateCategoryDTO createModel)
        {
            _logger.LogInformation($"Создание категории. / method: CreateServiceAsync");
            if (await _categoryRep.GetByAsync(x => x.CategoryName == createModel.CategoryName) != null)
            {
                _logger.LogWarning("Категория с таким наименованием существует.");
                _baseResponse.DisplayMessage = "Категория с таким наименованием существует.";
                _baseResponse.Status = Status.ExistsName;
                return _baseResponse!;
            }

            var category = _mapper.Map<Category>(createModel);

            if (createModel.Image != null)
            {
                var image = await _imageAccessorSer.AddImageAsync(createModel.Image).ConfigureAwait(true);
                if (image is null) _logger.LogInformation("Изображение не создано.");
                else
                {
                    _logger.LogInformation("Изображение создано.");
                    category.ImageUrl = image.Url;
                    category.ImageId = image.PublicId;
                };
            };

            var categoryRep = await _categoryRep.CreateAsync(category);
            if (categoryRep != null)
            {
                _logger.LogInformation("Категория создана.");
            }
            else
            {
                _logger.LogInformation("Категория не создана.");
                _baseResponse.DisplayMessage = "Категория не создана.";
                _baseResponse.Status = Status.NotCreate;
            }
            _baseResponse.Result = _mapper.Map<CategoryDTO>(categoryRep);
            _logger.LogInformation($"Ответ отправлен контролеру/method: CreateServiceAsync");
            return _baseResponse!;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            _logger.LogInformation($"Удаление категории. / method: DeleteServiceAsync");
            var baseResponse = new BaseResponse<bool>();
            _logger.LogInformation($"Поиск категории по id: {id}. / method: DeleteServiceAsync");
            Category category = await _categoryRep.GetByAsync(x => x.CategoryId == id, true);
            if (category is null)
            {
                _logger.LogWarning($"Категория c id: {id} не найдена.");
                baseResponse.DisplayMessage = $"Категория c id: {id} не найдена.";
                baseResponse.Result = false;
                _logger.LogInformation($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return baseResponse;
            }

            if (category.ImageId != null) await _imageAccessorSer.DeleteImageAsync(category.ImageId);

            await _categoryRep.DeleteAsync(category);
            baseResponse.DisplayMessage = "Категория удалена.";
            baseResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return baseResponse;
        }
        #endregion

        #region GetById
        /// <summary>
        /// Вывод категории
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<CategoryDTO>> GetByIdServiceAsync(int id)
        {
            _logger.LogInformation($"Поиск категории по id: {id}. / method: GetByIdServiceAsync");
            Category category = await _categoryRep.GetByAsync(x => x.CategoryId == id);
            if (category is null)
            {
                _logger.LogWarning($"Категория по id [{id}] не найдена");
                _baseResponse.DisplayMessage = $"Категория по id [{id}] не найдена";
                _baseResponse.Status = Status.NotFound;
            }
            else
            {
                _logger.LogInformation($"Вывод категории по id [{id}]");
            }
            _baseResponse.Result = _mapper.Map<CategoryDTO>(category);
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return _baseResponse!;
        }
        #endregion

        #region Get
        /// <summary>
        /// Список категорий (возможно приминение фильра и поиска)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<List<CategoryDTO>>> GetServiceAsync(string? filter = null, string? search = null)
        {
            _logger.LogInformation($"Список категорий. / method: GetServiceAsync");
            var bResponse = new BaseResponse<List<CategoryDTO>>();
            IEnumerable<Category>? categorys = null;
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(categorys, filter, search);
                categorys = result.Item1;
                _baseResponse.DisplayMessage = result.Item2;
            }
            if (!string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(categorys, filter);
                categorys = result.Item1;
                _baseResponse.DisplayMessage = result.Item2;
            }
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                categorys = await _categoryRep.GetAsync(search: search);
            }
            if (categorys is null)
            {
                _logger.LogInformation("Список категорий пуст.");
                _baseResponse.DisplayMessage = "Список категорий пуст.";
            }
            else
            {
                _logger.LogInformation("Список категорий.");
                IEnumerable<CategoryDTO> listCategorys = _mapper.Map<IEnumerable<CategoryDTO>>(categorys);
                bResponse.Result = listCategorys.ToList();
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetServiceAsync");
            return bResponse;
        }
        #endregion

        #region Update
        /// <summary>
        /// Обновление категории.
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<CategoryDTO>> UpdateServiceAsync(UpdateCategoryDTO updateModel)
        {
            _logger.LogInformation($"Обновление категории.");
            var carent = await _categoryRep.GetByAsync(x => x.CategoryId == updateModel.CategoryId);
            if (carent is null)
            {
                _logger.LogWarning("Попытка обновить объект, которого нет в хранилище.");
                _baseResponse.Status = Status.NotFound;
                _baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var category = _mapper.Map<Category>(updateModel);
                if (updateModel.Image  != null)
                {
                    var image = await _imageAccessorSer.AddImageAsync(updateModel.Image, updateModel.ImageId).ConfigureAwait(true);
                    if (image is null) _logger.LogInformation("Изображение не создано.");
                    else
                    {
                        _logger.LogInformation("Изображение создано.");
                        category.ImageUrl = image.Url;
                        category.ImageId = image.PublicId;
                    };
                }
                var categoryRep = await _categoryRep.UpdateAsync(category, carent); ;
                _baseResponse.DisplayMessage = "Категория обновилась.";
                _baseResponse.Result = _mapper.Map<CategoryDTO>(categoryRep);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return _baseResponse!;
        }
        #endregion

        #region Filter
        /// <summary>
        /// Фильтр и поиск категорий по значению
        /// </summary>
        /// <param name="categorys"></param>
        /// <param name="filter"></param>
        /// <returns>Отфильтрованный список и сообщение</returns>
        private async Task<(IEnumerable<Category>?, string)> FilterAndSearchAsync(IEnumerable<Category>? categorys, string filter, string? search = null)
        {
            _logger.LogInformation($"Поиск категории по фильтру: {filter}. / method: FilterAsync");
            Uri? uri;
            if (Uri.TryCreate(filter, UriKind.Absolute, out uri)
                && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                categorys = await _categoryRep.GetAsync(x => x.ImageUrl == uri.ToString(), search);

                if (categorys is null)
                    message = Message.FilterAndSearch(_logger, true, "категорий", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "категорий", filter, search);
            }
            else
            {
                categorys = await _categoryRep.GetAsync(x => x.CategoryName == filter, search);
                if (categorys is null)
                    message = Message.FilterAndSearch(_logger, true, "категорий", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "категорий", filter, search);
            }
            _logger.LogInformation($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
            return (categorys, message);
        }
        #endregion
    }
}
