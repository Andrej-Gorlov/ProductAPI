using Microsoft.Extensions.Logging;
using ProductAPI.Service.Helpers;

namespace ProductAPI.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRep;
        private IMapper _mapper;
        private BaseResponse<CategoryDTO> baseResponse;
        private readonly ILogger<CategoryService> _logger;
        private string message = "";
        public CategoryService(ICategoryRepository categoryRep, IMapper mapper, ILogger<CategoryService> logger)
        {
            _categoryRep = categoryRep;
            _mapper = mapper;
            _logger = logger;
            baseResponse = new();
        }
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
                baseResponse.DisplayMessage = "Категория с таким наименованием существует.";
                baseResponse.Status = Status.ExistsName;
                return baseResponse;
            }
            var category = await _categoryRep.CreateAsync(_mapper.Map<Category>(createModel));
            if (category != null)
            {
                _logger.LogInformation("Категория создана.");
            }
            else
            {
                _logger.LogInformation("Категория не создана.");
                baseResponse.DisplayMessage = "Категория не создана.";
                baseResponse.Status = Status.NotCreate;
            }
            baseResponse.Result = _mapper.Map<CategoryDTO>(category);
            _logger.LogInformation($"Ответ отправлен контролеру/method: CreateServiceAsync");
            return baseResponse;
        }
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
            await _categoryRep.DeleteAsync(category);
            baseResponse.DisplayMessage = "Категория удалена.";
            baseResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return baseResponse;
        }
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
                baseResponse.DisplayMessage = $"Категория по id [{id}] не найдена";
                baseResponse.Status = Status.NotFound;
            }
            else
            {
                _logger.LogInformation($"Вывод категории по id [{id}]");
            }
            baseResponse.Result = _mapper.Map<CategoryDTO>(category);
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Список категорий (возможно приминение фильра и поиска)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<List<CategoryDTO>>> GetServiceAsync(string? filter = null, string? search = null)
        {
            _logger.LogInformation($"Список категорий. / method: GetServiceAsync");
            var bResponse = new BaseResponse <List<CategoryDTO>>();
            IEnumerable<Category>? categorys = null;
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(categorys, filter, search);
                categorys = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (!string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(categorys, filter);
                categorys = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                categorys = await _categoryRep.GetAsync(search: search);
            }
            if (categorys is null)
            {
                _logger.LogInformation("Список категорий пуст.");
                baseResponse.DisplayMessage = "Список категорий пуст.";
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
                baseResponse.Status = Status.NotFound;
                baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var category = await _categoryRep.UpdateAsync(_mapper.Map<Category>(updateModel), carent); ;
                baseResponse.DisplayMessage = "Категория обновилась.";
                baseResponse.Result = _mapper.Map<CategoryDTO>(category);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return baseResponse;
        }
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

        /// <summary>
        /// Поиск категории по значению 
        /// </summary>
        /// <param name="categorys"></param>
        /// <param name="search"></param>
        /// <returns>Искомые категории и сообщение</returns>
        //private async Task<(IEnumerable<Category>?, string)> SearchAsync(IEnumerable<Category>? categorys, string search)
        //{
        //    WatchLogger.Log($"Поиск категории по: {search}. / method: SearchAsync");
        //    await Task.Factory.StartNew(() =>
        //    {
        //        categorys = categorys.Where(
        //            x => EF.Functions.Like(x.CategoryName.ToUpper(), $"%{search.ToUpper()}%"));
        //    });
        //    if (categorys.Count() is 0)
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
        //    return (categorys, message);
        //}
    }
}
