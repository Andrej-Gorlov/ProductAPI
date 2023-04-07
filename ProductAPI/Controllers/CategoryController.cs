namespace ProductAPI.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    //[ApiVersionNeutral]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categorySer;
        private readonly ILogger<Category> _logger;
        public CategoryController(ICategoryService categorySer, ILogger<Category> logger)
        {
            _categorySer = categorySer;
            _logger = logger;
        }

        #region Get
        /// <summary>
        /// Список категорий (возможно приминение фильра и поиска).
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <param name="search">Поиск</param>
        /// <returns>Вывод всех категорий</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /categorys
        ///     
        ///        filter: Фильтр   // Введите значение фильтра (Необязательно).
        ///        search: Поиск    // Введите значение поиска (Необязательно).
        ///
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список категорий не найден. </response>
        [HttpGet]
        //[MapToApiVersion("2.0")]
        [ResponseCache(CacheProfileName = "Default30")]
        [Route("categorys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] string? filter, [FromQuery] string? search)
        {
            _logger.LogInformation($"выполнен вход. /CategoryController/method: Get");
            IBaseResponse<List<CategoryDTO>> categorys;
            if (!(filter is null) && !(search is null))
            {
                _logger.LogInformation($"Получение списка категорий по фильтру: {filter} и поиску: {search}.");
                categorys = await _categorySer.GetServiceAsync(filter, search);
            }
            else if (!(filter is null) && (search is null))
            {
                _logger.LogInformation($"Получение списка категорий по фильтру: {filter}.");
                categorys = await _categorySer.GetServiceAsync(filter);
            }
            else if (filter is null && !(search is null))
            {
                _logger.LogInformation($"Получение списка категорий по поиску: {search}.");
                categorys = await _categorySer.GetServiceAsync(search:search);
            }
            else
            {
                _logger.LogInformation($"Получение списка категорий.");
                categorys = await _categorySer.GetServiceAsync();
            }
            if (categorys.Result is null)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /CategoryController/method: Get");
                return NotFound(categorys);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /CategoryController/method: Get");
            return Ok(categorys);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Вывод категории по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных категории</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /category/{id:int}
        ///     
        ///        Id: 0   // Введите id категории, которую нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> категория не найдена </response>
        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("category/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"выполнен вход. /CategoryController/method: GetById");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {BadRequest().StatusCode} /CategoryController/method: GetById");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            _logger.LogInformation($"Получение категории по id: {id}.");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.GetByIdServiceAsync(id);
            if (category.Status is Status.NotFound)
            {
                _logger.LogWarning($"Ответ отправлен. статус: {NotFound().StatusCode} /CategoryController/method: GetById");
                return NotFound(category);
            }
            _logger.LogInformation($"Ответ отправлен. статус: {Ok().StatusCode} /CategoryController/method: GetById");
            return Ok(category);
        }
        #endregion

        #region Create
        /// <summary>
        /// Создание новой категории.
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns>Создаётся категория</returns>
        /// <remarks>
        /// 
        ///     POST /category   
        ///     
        /// </remarks>
        /// <response code="201"> Категория создана. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        [HttpPost]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDTO categoryDTO)
        {
            _logger.LogInformation($"выполнен вход. /CategoryController/method: Create");
            _logger.LogInformation($"Создание новой категории");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.CreateServiceAsync(categoryDTO);
            if (category.Status is Status.ExistsName)
            {
                _logger.LogWarning($"Ответ отправлен. Категория с таким названием уже существует. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Create");
                return BadRequest(category);
            }
            if (category.Status is Status.NotCreate)
            {
                _logger.LogWarning($"Ответ отправлен. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Create");
                return BadRequest(category);
            }
            _logger.LogInformation($"Ответ отправлен. Cтатус: 201 /CategoryController/method: Create");
            return CreatedAtAction(nameof(Get), category);
        }
        #endregion

        #region Update
        /// <summary>
        /// Обновление категории.
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns>Обновление категории.</returns>
        /// <remarks>
        ///
        ///     PUT /category
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Категория не найдена. </response>
        [HttpPut]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDTO categoryDTO)
        {
            _logger.LogInformation($"выполнен вход. /CategoryController/method: Update");
            _logger.LogInformation($"Обновление категории");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.UpdateServiceAsync(categoryDTO);
            if (category.Status is Status.NotFound)
            {
                _logger.LogWarning($"Ответ отправлен. Cтатус: {NotFound().StatusCode} /CategoryController/method: Update");
                return NotFound(category);
            }
            _logger.LogInformation($"Ответ отправлен. Cтатус: {Ok().StatusCode} /CategoryController/method: Update");
            return Ok(category);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление категории.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Категория удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /category/{id}
        ///     
        ///        Id: 0   // Введите id категории, которую нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Категория удалёна. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Категория c указанным id не найдена. </response>
        [HttpDelete]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"выполнен вход. /CategoryController/method: Delete");
            if (id <= 0)
            {
                _logger.LogWarning($"Ответ отправлен. id: [{id}] не может быть меньше или равно нулю. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Delete");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            _logger.LogInformation("Удаление категории.");
            var category = await _categorySer.DeleteServiceAsync(id);
            if (category.Result is false)
            {
                _logger.LogWarning($"Ответ отправлен. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Delete");
                return NotFound(category);
            }
            _logger.LogInformation($"Ответ отправлен. Cтатус: {NoContent().StatusCode} /CategoryController/method: Delete");
            return Ok(category);
        }
        #endregion
    }
}
