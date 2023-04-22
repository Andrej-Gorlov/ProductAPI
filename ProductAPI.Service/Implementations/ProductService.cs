namespace ProductAPI.Service.Implementations
{
    public class ProductService : BaseService<ProductService, ProductDTO>,IProductService
    {
        private IProductRepository _productRep;

        public ProductService(IProductRepository productRep, ICategoryRepository categoryRep, IMapper mapper, ILogger<ProductService> logger)
            :base(mapper, logger,new()) => _productRep = productRep;

        /// <summary>
        /// Создание продукта.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ProductDTO>> CreateServiceAsync(CreateProductDTO createModel)
        {
            _logger.LogInformation($"Создание продукта. / method: CreateServiceAsync");
            if (await _productRep.GetByAsync(x => x.ProductName == createModel.ProductName) != null)
            {
                _logger.LogWarning("Продукт с таким наименованием существует.");
                _baseResponse.DisplayMessage = "Продукт с таким наименованием существует.";
                _baseResponse.Status = Status.ExistsName;
                return _baseResponse;
            }
            if (await _productRep.GetByAsync(x => x.MainImageUrl == createModel.MainImageUrl) != null)
            {
                _logger.LogWarning("Продукт с таким url адрессом изображения существует.");
                _baseResponse.DisplayMessage = "Продукт с таким url адрессом изображения существует.";
                _baseResponse.Status = Status.ExistsUrl;
                return _baseResponse;
            }
            var product = await _productRep.CreateAsync(_mapper.Map<Product>(createModel));
            if (product != null)
            {
                _logger.LogInformation("Продукт создан.");
            }
            else
            {
                _logger.LogWarning("Продукт не создан.");
                _baseResponse.DisplayMessage = "Продукт не создан.";
                _baseResponse.Status = Status.NotCreate;
            }
            _baseResponse.Result = _mapper.Map<ProductDTO>(product);
            _logger.LogInformation($"Ответ отправлен контролеру/method: CreateServiceAsync");
            return _baseResponse;
        }
        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            _logger.LogInformation($"Удаление продукта. / method: DeleteServiceAsync");
            var baseResponse = new BaseResponse<bool>();
            _logger.LogInformation($"Поиск продукта по id: {id}. / method: DeleteServiceAsync");
            Product product = await _productRep.GetByAsync(x => x.ProductId == id, true);
            if (product is null)
            {
                _logger.LogWarning($"Продукт c id: {id} не найден.");
                baseResponse.DisplayMessage = $"Продукт c id: {id} не найден.";
                baseResponse.Result = false;
                _logger.LogInformation($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return baseResponse;
            }
            await _productRep.DeleteAsync(product);
            baseResponse.DisplayMessage = "Продукт удален.";
            baseResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Вывод продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ProductDTO>> GetByIdServiceAsync(int id)
        {
            _logger.LogInformation($"Поиск продукта по id: {id}. / method: GetByIdServiceAsync");
            Product product = await _productRep.GetByAsync(x => x.ProductId == id);
            if (product is null)
            {
                _logger.LogWarning($"Продукт по id [{id}] не найден.");
                _baseResponse.DisplayMessage = $"Продукт по id [{id}] не найден.";
                _baseResponse.Status = Status.NotFound;
            }
            else
            {
                _logger.LogInformation($"Вывод продукта по id [{id}]");
            }
            _baseResponse.Result = _mapper.Map<ProductDTO>(product);
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return _baseResponse;
        }
        /// <summary>
        /// Список продуктов (возможно приминение фильра и поиска)
        /// </summary>
        /// <param name="paging"></param>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<PagedList<ProductDTO>>> GetServiceAsync(PagingQueryParameters paging, string? filter = null, string? search = null)
        {
            _logger.LogInformation($"Список продуктов. /method: GetServiceAsync");
            var baseResponse = new BaseResponse<PagedList<ProductDTO>>();
            string[] includeProperties = { nameof(ProductDTO.Category), nameof(ProductDTO.SecondaryImages)};
            IEnumerable<Product>? products = null;
            if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(products, includeProperties, filter, search);
                products = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (!string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                var result = await FilterAndSearchAsync(products, includeProperties, filter);
                products = result.Item1;
                baseResponse.DisplayMessage = result.Item2;
            }
            if (string.IsNullOrEmpty(filter) && string.IsNullOrEmpty(search))
            {
                products = await _productRep.GetAsync(search: search, includeProperties: includeProperties);
            }
            if (products is null)
            {
                _logger.LogWarning("Список продуктов пуст.");
                baseResponse.DisplayMessage = "Список продуктов пуст.";
            }
            else
            {
                _logger.LogInformation("Список продуктов.");
                IEnumerable<ProductDTO> listProducts = _mapper.Map<IEnumerable<ProductDTO>>(products);
                _logger.LogInformation("применение пагинации. /method: GetServiceAsync");
                baseResponse.Result = PagedList<ProductDTO>.ToPagedList(listProducts, paging.PageNumber, paging.PageSize);
                baseResponse.ParameterPaged = baseResponse.Result.Parameter;
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: GetServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Частичное обновление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<ProductDTO>> UpdatePatrialServiceAsync(int id, JsonPatchDocument<UpdatePatrialProductDTO> updateModel)
        {
            _logger.LogInformation($"Частичное обновление. /method: UpdatePatrialServiceAsync");
            var carent = await _productRep.GetByAsync(x => x.ProductId == id, false);
            if (carent is null)
            {
                _logger.LogWarning($"Попытка обновить объект, которого нет в хранилище.");
                _baseResponse.Status = Status.NotFound;
                _baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var entity = _mapper.Map<UpdatePatrialProductDTO>(carent);
                updateModel.ApplyTo(entity);
                Product entityProduct = await _productRep.UpdateAsync(_mapper.Map<Product>(entity), carent);
                _logger.LogInformation("Продукт отредактирован.");
                _baseResponse.DisplayMessage = "Продукт отредактирован.";
                _baseResponse.Result = _mapper.Map<ProductDTO>(entityProduct);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdatePatrialServiceAsync");
            return _baseResponse;
        }
        /// <summary>
        /// Обновление продукта.
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<ProductDTO>> UpdateServiceAsync(UpdateProductDTO updateModel)
        {
            _logger.LogInformation($"Обновление продукта.");
            var carent = await _productRep.GetByAsync(x => x.ProductId == updateModel.ProductId);
            if (carent is null)
            {
                _logger.LogWarning("Попытка обновить объект, которого нет в хранилище.");
                _baseResponse.Status = Status.NotFound;
                _baseResponse.DisplayMessage = "Попытка обновить объект, которого нет в хранилище.";
            }
            else
            {
                var product = await _productRep.UpdateAsync(_mapper.Map<Product>(updateModel), carent);
                _baseResponse.DisplayMessage = "Продукт обновился.";
                _baseResponse.Result = _mapper.Map<ProductDTO>(product);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return _baseResponse;
        }
        /// <summary>
        /// Фильтр и поиск продуктов по значению
        /// </summary>
        /// <param name="products"></param>
        /// <param name="includeProperties"></param>
        /// <param name="filter"></param>
        /// <param name="search"></param>
        /// <returns>Отфильтрованный список и сообщение</returns>
        private async Task<(IEnumerable<Product>?, string)> FilterAndSearchAsync(IEnumerable<Product>? products, string[] includeProperties, string filter, string? search = null)
        {
            _logger.LogInformation($"Поиск продуктов по фильтру: {filter}. / method: FilterAsync");
            DateTime date;
            double price;
            if (DateTime.TryParse(filter.ToString(), out date))
            {
                products = await _productRep.GetAsync(x => x.CreateDateTime.Date == date.Date, search, includeProperties: includeProperties);

                if (products is null)
                    message = Message.FilterAndSearch(_logger, true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "продуктов", filter, search);
            }
            else if (Double.TryParse(filter.ToString(), out price))
            {
                products = await _productRep.GetAsync(x => x.Price == price, search, includeProperties: includeProperties);
                if (products is null)
                    message = Message.FilterAndSearch(_logger, true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "продуктов", filter, search);
            }
            else
            {
                products = await _productRep.GetAsync(x => x.ProductName == filter, search, includeProperties: includeProperties);

                if (products.Count() is 0)  products = await _productRep.GetAsync(x => x.Category.CategoryName == filter, search, includeProperties: includeProperties);

                if (products.Count() is 0)
                    message = Message.FilterAndSearch(_logger, true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "продуктов", filter, search);
            }
            _logger.LogInformation($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
            return (products, message);
        }

        /// <summary>
        /// Поиск продукта по значению 
        /// </summary>
        /// <param name="products"></param>
        /// <param name="search"></param>
        /// <returns>Искомые продукты и сообщение</returns>
        //private async Task<(IEnumerable<Product>?, string)> SearchAsync(IQueryable<Product>? products, string search)
        //{
        //    WatchLogger.Log($"Поиск продукта по: {search}. / method: SearchAsync");
        //    await Task.Factory.StartNew(() =>
        //    {

        //    //x => EF.Functions.Like(x.ImageUrl.ToUpper(), $"%{search.ToUpper()}%"));
        //    products = products.Where( //<- проверить на коректность (CreateDateTime)
        //            x => EF.Functions.Like(x.ProductName, $"%{search}%")
        //            //|| x.Price.ToString().Contains(search, StringComparison.OrdinalIgnoreCase)
        //            //|| x.CreateDateTime.ToString("d").Contains(search, StringComparison.OrdinalIgnoreCase)
        //            || EF.Functions.Like(x.Category.CategoryName, $"%{search}%")
        //            );
        //    });
        //    if (products.Count() is 0)
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
        //    return (products, message);
        //}
    }
}
