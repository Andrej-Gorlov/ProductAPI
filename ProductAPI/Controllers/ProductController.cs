namespace ProductAPI.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    //[ApiVersionNeutral]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productSer;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productSer, ILogger<ProductController> logger)
        {
            _productSer = productSer;
            _logger = logger;
        } 

        #region Get
        /// <summary>
        /// Список всех продуктов.
        /// </summary>
        /// <param name="paging">Пагинация</param>
        /// <param name="filter">Фильтр</param>
        /// <param name="search">Поиск</param>
        /// <returns>Вывод всех продуктов</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /products
        ///     
        ///        PageNumber: Номер страницы   // Введите номер страницы, которую нужно показать с списоком продуктов (Необязательно).
        ///        PageSize: Размер страницы    // Введите размер страницы, какое количество продуктов нужно вывести (Необязательно).
        ///        filter: Фильтр               // Введите значение фильтра (Необязательно).
        ///        search: Поиск                // Введите значение поиска (Необязательно).
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список продуктов не найден. </response>
        [HttpGet]
        [Route("products")]
        [ResponseCache(CacheProfileName = "Default30")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PagingQueryParameters paging, [FromQuery] string? filter, [FromQuery] string? search)
        {
            _logger.LogInformation("выполнен вход. /ProductController/method: Get");
            IBaseResponse<PagedList<ProductDTO>>? products = null;

            if (!(filter is null) && !(search is null))
            {
                _logger.LogInformation($"Получение списка продуктов по фильтру: {filter} и поиску: {search}.");
                products = await _productSer.GetServiceAsync(paging, filter, search);
            }
            else if (!(filter is null) && search is null)
            {
                _logger.LogInformation($"Получение списка продуктов по фильтру: {filter}.");
                products = await _productSer.GetServiceAsync(paging, filter);
            }
            else if (filter is null && !(search is null))
            {
                _logger.LogInformation($"Получение списка продуктов по поиску: {search}.");
                products = await _productSer.GetServiceAsync(paging, search: search);
            }
            else if (filter is null && search is null)
            {
                _logger.LogInformation($"Получение списка продуктов.");
                products = await _productSer.GetServiceAsync(paging);
            }

            if (products.Result is null)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Get");
                return NotFound(products);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Get");
            return Ok(products);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Вывод продукта по id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Вывод данных продукта</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /product/{id:int}
        ///     
        ///        Id: 0   // Введите id продукта, которого нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Продукт не найден.</response>
        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("product/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"выполнен вход. /ProductController/method: GetById");
            if (id <= 0)
            {
                _logger.LogInformation($"Ответ отправлен. id: [{id}] не может быть меньше или равно нулю. статус: {NotFound().StatusCode} /ImageController/method: GetById");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            _logger.LogInformation($"Получение продукта по id: {id}.");
            var product = (BaseResponse<ProductDTO>)await _productSer.GetByIdServiceAsync(id);
            if (product.Status is Status.NotFound)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: GetById");
                return NotFound(product);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: GetById");
            return Ok(product);
        }
        #endregion

        #region Create
        /// <summary>
        /// Создание нового продукта.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns>Создаётся продукт.</returns>
        /// <remarks>
        /// 
        ///     POST /product 
        ///     
        ///         Authorize roles: ADMIN, OWNER
        ///     
        /// </remarks>
        /// <response code="201"> Продукт создан. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="401"> Пользователь не авторизован. </response>
        [HttpPost]
        [Route("product")]
        [Authorize(Roles = $"{UserRoles.ADMIN}, ${UserRoles.OWNER}", 
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO productDTO)
        {
            _logger.LogInformation($"выполнен вход. /ProductController/method: Create");
            _logger.LogInformation($"Создание нового продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.CreateServiceAsync(productDTO);
            if (product.Status is Status.ExistsName)
            {
                _logger.LogWarning($"Ответ отправлен. Продукт с таким наименованием существует. Статус: {BadRequest().StatusCode} /ImageController/method: Create");
                return BadRequest(product);
            }
            if (product.Status is Status.ExistsUrl)
            {
                _logger.LogWarning($"Ответ отправлен. Продукт с таким url адрессом изображения существует. Статус: {BadRequest().StatusCode} /ImageController/method: Create");
                return BadRequest(product);
            }
            if (product.Status is Status.NotCreate)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Create");
                return BadRequest(product);
            }
            _logger.LogInformation($"Ответ отправлен. статус: 201 /ProductController/method: Create");
            return CreatedAtAction(nameof(Get), product);
        }
        #endregion

        #region Update
        /// <summary>
        /// Обновление продукта.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns>Обновление продукта.</returns>
        /// <remarks>
        ///
        ///     PUT /product
        ///     
        ///         Authorize roles: ADMIN, OWNER
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Продукт не найден. </response>
        /// <response code="401"> Пользователь не авторизован. </response>
        [HttpPut]
        [Route("product")]
        [Authorize(Roles = $"{UserRoles.ADMIN}, ${UserRoles.OWNER}",
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO productDTO)
        {
            _logger.LogInformation($"выполнен вход. /ProductController/method: Update");
            _logger.LogInformation($"Обновление продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.UpdateServiceAsync(productDTO);
            if (product.Status is Status.NotFound)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Update");
                return NotFound(product);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Update");
            return Ok(product);
        }
        #endregion

        #region UpdatePatrial
        /// <summary>
        /// Частичное редактирование продукта.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns>Частичное обновление продукта.</returns>
        /// <remarks>
        ///
        ///     Patch /product
        ///     
        ///         Authorize roles: ADMIN, OWNER
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Продукт не найден. </response>
        /// <response code="401"> Пользователь не авторизован. </response>
        [HttpPatch]
        [Route("product")]
        [Authorize(Roles = $"{UserRoles.ADMIN}, ${UserRoles.OWNER}",
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdatePatrial(int id, JsonPatchDocument<UpdatePatrialProductDTO> productDto)
        {
            _logger.LogInformation($"выполнен вход. /ProductController/method: UpdatePatrial");
            if (productDto.Operations.FirstOrDefault(x => x.op == "replace") != null)
            {
                ///////запрещино 
            }
            if (productDto is null || id <= 0)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {BadRequest().StatusCode} /ProductController/method: UpdatePatrial");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            _logger.LogInformation($"Частичное обновление продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.UpdatePatrialServiceAsync(id, productDto);
            if (product.Status is Status.NotFound)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: UpdatePatrial");
                return NotFound(product);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: UpdatePatrial");
            return Ok(product);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление продукта.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Продукт удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /product/{id}
        ///         
        ///        Authorize roles: ADMIN
        ///        Id: 0   // Введите id продукта, которого нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Продукт удалён. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Продукт c указанным id не найден. </response>
        /// <response code="401"> Пользователь не авторизован. </response>
        [HttpDelete]
        [Route("product/{id}")]
        [Authorize(Roles = UserRoles.ADMIN)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"выполнен вход. /ProductController/method: Delete");
            if (id <= 0)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {BadRequest().StatusCode} /ProductController/method: Delete");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            _logger.LogInformation($"Удаление продукта.");
            var product = await _productSer.DeleteServiceAsync(id);
            if (product.Result is false)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Delete");
                return NotFound(product);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Delete");
            return Ok(product);
            //return NoContent();
        }
        #endregion
    }
}
