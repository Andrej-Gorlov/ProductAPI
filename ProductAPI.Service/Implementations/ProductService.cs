using ProductAPI.Service.Helpers;

namespace ProductAPI.Service.Implementations
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRep;
        private IMapper _mapper;
        private BaseResponse<ProductDTO> baseResponse;
        private string message = "";
        public ProductService(IProductRepository productRep, IMapper mapper)
        {
            _productRep = productRep;
            _mapper = mapper;
            baseResponse = new();
        }
        /// <summary>
        /// Создание продукта.
        /// </summary>
        /// <param name="createModel"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ProductDTO>> CreateServiceAsync(CreateProductDTO createModel)
        {
            WatchLogger.Log($"Создание продукта. / method: CreateServiceAsync");
            if (await _productRep.GetByAsync(x => x.ProductName == createModel.ProductName) != null)
            {
                WatchLogger.Log("Продукт с таким наименованием существует.");
                baseResponse.DisplayMessage = "Продукт с таким наименованием существует.";
                baseResponse.Status = Status.ExistsName;
                return baseResponse;
            }
            var product = await _productRep.CreateAsync(_mapper.Map<Product>(createModel));
            if (product != null)
            {
                WatchLogger.Log("Продукт создан.");
            }
            else
            {
                WatchLogger.Log("Продукт не создан.");
                baseResponse.DisplayMessage = "Продукт не создан.";
            }
            baseResponse.Result = _mapper.Map<ProductDTO>(product);
            WatchLogger.Log($"Ответ отправлен контролеру/method: CreateServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Удаление продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<bool>> DeleteServiceAsync(int id)
        {
            WatchLogger.Log($"Удаление продукта. / method: DeleteServiceAsync");
            var baseResponse = new BaseResponse<bool>();
            WatchLogger.Log($"Поиск продукта по id: {id}. / method: DeleteServiceAsync");
            Product product = await _productRep.GetByAsync(x => x.CategoryId == id, true);
            if (product is null)
            {
                WatchLogger.Log($"Продукт c id: {id} не найден.");
                baseResponse.DisplayMessage = $"Продукт c id: {id} не найден.";
                baseResponse.Result = false;
                WatchLogger.Log($"Ответ отправлен контролеру (false)/ method: DeleteServiceAsync");
                return baseResponse;
            }
            await _productRep.DeleteAsync(product);
            baseResponse.DisplayMessage = "Продукт удален.";
            baseResponse.Result = true;
            WatchLogger.Log($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Вывод продукта
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Базовый ответ.</returns>
        public async Task<IBaseResponse<ProductDTO>> GetByIdServiceAsync(int id)
        {
            WatchLogger.Log($"Поиск продукта по id: {id}. / method: GetByIdServiceAsync");
            Product product = await _productRep.GetByAsync(x => x.ProductId == id);
            if (product is null)
            {
                WatchLogger.Log($"Продукт по id [{id}] не найден.");
                baseResponse.DisplayMessage = $"Продукт по id [{id}] не найден.";
            }
            else
            {
                WatchLogger.Log($"Вывод продукта по id [{id}]");
            }
            baseResponse.Result = _mapper.Map<ProductDTO>(product);
            WatchLogger.Log($"Ответ отправлен контролеру/ method: GetByIdServiceAsync");
            return baseResponse;
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
            WatchLogger.Log($"Список продуктов. /method: GetServiceAsync");
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
                WatchLogger.Log("Список продуктов пуст.");
                baseResponse.DisplayMessage = "Список продуктов пуст.";
            }
            else
            {
                WatchLogger.Log("Список продуктов.");
                IEnumerable<ProductDTO> listProducts = _mapper.Map<IEnumerable<ProductDTO>>(products);
                WatchLogger.Log("применение пагинации. /method: GetServiceAsync");
                baseResponse.Result = PagedList<ProductDTO>.ToPagedList(
                    listProducts, paging.PageNumber, paging.PageSize);
            }
            WatchLogger.Log($"Ответ отправлен контролеру/ method: GetServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Частичное обновление
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<ProductDTO>> UpdatePatrialServiceAsync(int id, JsonPatchDocument<UpdateProductDTO> updateModel)
        {
            WatchLogger.Log($"Частичное обновление. /method: UpdatePatrialServiceAsync");
            var carent = await _productRep.GetByAsync(x => x.ProductId == id, false);
            if (carent is null)
            {
                WatchLogger.Log($"Попытка обновить объект, которого нет в хранилище.");
                throw new NullReferenceException("Попытка обновить объект, которого нет в хранилище.");
            }
            var entity = _mapper.Map<UpdateProductDTO>(carent);
            updateModel.ApplyTo(entity);
            Product entityProduct = await _productRep.UpdateAsync(_mapper.Map<Product>(entity), carent);
            WatchLogger.Log("Продукт отредактирован.");
            baseResponse.DisplayMessage = "Продукт отредактирован.";
            baseResponse.Result = _mapper.Map<ProductDTO>(entityProduct);
            WatchLogger.Log($"Ответ отправлен контролеру/ method: UpdatePatrialServiceAsync");
            return baseResponse;
        }
        /// <summary>
        /// Обновление продукта.
        /// </summary>
        /// <param name="updateModel"></param>
        /// <returns>Базовый ответ.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IBaseResponse<ProductDTO>> UpdateServiceAsync(UpdateProductDTO updateModel)
        {
            WatchLogger.Log($"Обновление продукта.");
            var carent = await _productRep.GetByAsync(x => x.ProductId == updateModel.ProductId, false);
            if (carent is null)
            {
                WatchLogger.Log("Попытка обновить объект, которого нет в хранилище.");
                throw new NullReferenceException("Попытка обновить объект, которого нет в хранилище.");
            }
            var product = await _productRep.UpdateAsync(_mapper.Map<Product>(updateModel), carent);
            baseResponse.DisplayMessage = "Продукт обновился.";
            baseResponse.Result = _mapper.Map<ProductDTO>(product);
            WatchLogger.Log($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return baseResponse;
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
            WatchLogger.Log($"Поиск продуктов по фильтру: {filter}. / method: FilterAsync");
            DateTime date;
            double price;
            if (DateTime.TryParse(filter.ToString(), out date))
            {
                products = await _productRep.GetAsync(x => x.CreateDateTime.Date == date.Date, search, includeProperties: includeProperties);

                if (products is null)
                    message = Message.FilterAndSearch(true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(false, "продуктов", filter, search);
            }
            else if (Double.TryParse(filter.ToString(), out price))
            {
                products = await _productRep.GetAsync(x => x.Price == price, search, includeProperties: includeProperties);
                if (products is null)
                    message = Message.FilterAndSearch(true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(false, "продуктов", filter, search);
            }
            else
            {
                products = await _productRep.GetAsync(x => x.ProductName == filter, search, includeProperties: includeProperties);
                if (products is null)
                    message = Message.FilterAndSearch(true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(false, "продуктов", filter, search);
            }
            WatchLogger.Log($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
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
