namespace ProductAPI.Service.Implementations
{
    public class ProductService : BaseService<ProductService, ProductDTO>,IProductService
    {
        private readonly IProductRepository _productRep;
        private readonly ICloudinaryActions _cloudinary;
        public ProductService(IProductRepository productRep, ICloudinaryActions cloudinary, IMapper mapper, ILogger<ProductService> logger)
            :base(mapper, logger, new())
        {
            _productRep = productRep;
            _cloudinary = cloudinary;
        }

        #region Create
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

            Product product = _mapper.Map<Product>(createModel);
            if(createModel.FileMainImage != null && createModel.FileMainImage.Length > 0)
            {
                var image = await _cloudinary.AddImageAsync(createModel.FileMainImage, product.ProductId);
                AssigningImageToProduct(image, product);
            }
            if (createModel.FileSecondaryImages != null)
            {
                var secondaryImages = await _cloudinary.AddImagesAsync(createModel.FileSecondaryImages, product.ProductId);
                AssigningImagesToProduct(secondaryImages, product);
            }

            var productRep = await _productRep.CreateAsync(product);
            if (productRep != null)
            {
                _logger.LogInformation("Продукт создан.");
            }
            else
            {
                _logger.LogWarning("Продукт не создан.");
                _baseResponse.DisplayMessage += "\nПродукт не создан.";
                _baseResponse.Status = Status.NotCreate;
            }
            _baseResponse.Result = _mapper.Map<ProductDTO>(productRep);
            _logger.LogInformation($"Ответ отправлен контролеру/method: CreateServiceAsync");
            return _baseResponse;
        }
        #endregion

        #region Delete
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
            if (product.ImageId != null)
            {
                await _cloudinary.DeleteImageAsync(product.ImageId);
            }
            if (product.SecondaryImages != null)
            {
                foreach (var image in product.SecondaryImages)
                {
                    if (image != null)
                    {
                        await _cloudinary.DeleteImageAsync(image.ImageId);
                    }
                }
            }
            await _productRep.DeleteAsync(product);
            baseResponse.DisplayMessage = "Продукт удален.";
            baseResponse.Result = true;
            _logger.LogInformation($"Ответ отправлен контролеру (true)/ method: DeleteServiceAsync");
            return baseResponse;
        }
        #endregion

        #region GetById
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
        #endregion

        #region Get
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
            string[] includeProperties = { nameof(ProductDTO.Category), nameof(ProductDTO.SecondaryImages) };
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
        #endregion

        #region Update
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
                var product = _mapper.Map<Product>(updateModel);
                if (updateModel.ImageId != null && updateModel.FileMainImage != null)
                {
                    var image = await _cloudinary.UpdateImageAsync(updateModel.FileMainImage, updateModel.ProductId, updateModel.ImageId);
                    AssigningImageToProduct(image, product);
                }
                if (updateModel.SecondaryImagesId != null && updateModel.FileSecondaryImages != null && 
                    updateModel.SecondaryImagesId.Count == updateModel.FileSecondaryImages.Count)
                {
                    var secondaryImages = await _cloudinary.UpdateImagesAsync(updateModel.FileSecondaryImages, product.ProductId, updateModel.SecondaryImagesId);
                    AssigningImagesToProduct(secondaryImages, product);
                }
                var productRep = await _productRep.UpdateAsync(product, carent);
                _baseResponse.DisplayMessage = "Продукт обновился.";
                _baseResponse.Result = _mapper.Map<ProductDTO>(productRep);
            }
            _logger.LogInformation($"Ответ отправлен контролеру/ method: UpdateServiceAsync");
            return _baseResponse;
        }
        #endregion

        #region Filter
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
            decimal price;
            if (DateTime.TryParse(filter.ToString(), out date))
            {
                products = await _productRep.GetAsync(x => x.CreateDateTime.Date == date.Date, search, includeProperties: includeProperties);

                if (products is null)
                    message = Message.FilterAndSearch(_logger, true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "продуктов", filter, search);
            }
            else if (Decimal.TryParse(filter.ToString(), out price))
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

                if (products.Count() is 0)  products = await _productRep.GetAsync(x => x.Category!.CategoryName == filter, search, includeProperties: includeProperties);

                if (products.Count() is 0)
                    message = Message.FilterAndSearch(_logger, true, "продуктов", filter, search);
                else
                    message = Message.FilterAndSearch(_logger, false, "продуктов", filter, search);
            }
            _logger.LogInformation($"Ответ отправлен GetServiceAsync/ method: FilterAsync");
            return (products, message);
        }
        #endregion

        #region Add image(s) in product
        /// <summary>
        /// Add image in product
        /// </summary>
        /// <param name="image"></param>
        /// <param name="product"></param>
        private void AssigningImageToProduct(Image? image, Product product)
        {
            if (image != null)
            {
                _logger.LogInformation("Изображение добавлено в API сloudinary.");
                _baseResponse.DisplayMessage = "Изображение добавлено в API сloudinary.";
                product.ImageId = image.ImageId;
                product.ImageUrl = image.ImageUrl;
            }
            else
            {
                _logger.LogInformation("Изображение не добавлено в API сloudinary.");
                _baseResponse.DisplayMessage = "Изображение не добавлено в API сloudinary.";
            }
        }
        /// <summary>
        /// Add images in product
        /// </summary>
        /// <param name="images"></param>
        /// <param name="product"></param>
        private void AssigningImagesToProduct(IList<Image>? images, Product product)
        {
            if (images != null)
            {
                _logger.LogInformation("Cписок изображений обнавлён в API сloudinary.");
                _baseResponse.DisplayMessage += $"\nCписок изображений добавлен в API сloudinary.";
                product.SecondaryImages = images;
            }
            else
            {
                _logger.LogInformation("Cписок изображений не обнавлён в API сloudinary.");
                _baseResponse.DisplayMessage += $"\nCписок изображений не добавлен в API сloudinary.";
            }
        }
        #endregion
    }
}
