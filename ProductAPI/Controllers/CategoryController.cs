namespace ProductAPI.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersionNeutral]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categorySer;
        public CategoryController(ICategoryService categorySer) => _categorySer = categorySer;

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
            WatchLogger.Log($"выполнен вход. /CategoryController/method: Get");
            IBaseResponse<List<CategoryDTO>> categorys;
            if (!(filter is null) && !(search is null))
            {
                WatchLogger.Log($"Получение списка категорий по фильтру: {filter} и поиску: {search}.");
                categorys = await _categorySer.GetServiceAsync(filter, search);
            }
            else if (!(filter is null) && (search is null))
            {
                WatchLogger.Log($"Получение списка категорий по фильтру: {filter}.");
                categorys = await _categorySer.GetServiceAsync(filter);
            }
            else if (filter is null && !(search is null))
            {
                WatchLogger.Log($"Получение списка категорий по поиску: {search}.");
                categorys = await _categorySer.GetServiceAsync(search:search);
            }
            else
            {
                WatchLogger.Log($"Получение списка категорий.");
                categorys = await _categorySer.GetServiceAsync();
            }
            if (categorys.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /CategoryController/method: Get");
                return NotFound(categorys);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /CategoryController/method: Get");
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
            WatchLogger.Log($"выполнен вход. /CategoryController/method: GetById");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {BadRequest().StatusCode} /CategoryController/method: GetById");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Получение категории по id: {id}.");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.GetByIdServiceAsync(id);
            if (category.Status is Status.NotFound)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /CategoryController/method: GetById");
                return NotFound(category);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /CategoryController/method: GetById");
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
            WatchLogger.Log($"выполнен вход. /CategoryController/method: Create");
            WatchLogger.Log($"Создание новой категории");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.CreateServiceAsync(categoryDTO);
            if (category.Status is Status.ExistsName)
            {
                WatchLogger.Log($"Ответ отправлен. Категория с таким названием уже существует. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Create");
                return BadRequest(category);
            }
            if (category.Status is Status.NotCreate)
            {
                WatchLogger.Log($"Ответ отправлен. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Create");
                return BadRequest(category);
            }
            WatchLogger.Log($"Ответ отправлен. Cтатус: 201 /CategoryController/method: Create");
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
            WatchLogger.Log($"выполнен вход. /CategoryController/method: Update");
            WatchLogger.Log($"Обновление категории");
            var category = (BaseResponse<CategoryDTO>)await _categorySer.UpdateServiceAsync(categoryDTO);
            if (category.Status is Status.NotFound)
            {
                WatchLogger.Log($"Ответ отправлен. Cтатус: {NotFound().StatusCode} /CategoryController/method: Update");
                return NotFound(category);
            }
            WatchLogger.Log($"Ответ отправлен. Cтатус: {Ok().StatusCode} /CategoryController/method: Update");
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
            WatchLogger.Log($"выполнен вход. /CategoryController/method: Delete");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. id: [{id}] не может быть меньше или равно нулю. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Delete");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log("Удаление категории.");
            var category = await _categorySer.DeleteServiceAsync(id);
            if (category.Result is false)
            {
                WatchLogger.Log($"Ответ отправлен. Cтатус: {BadRequest().StatusCode} /CategoryController/method: Delete");
                return NotFound(category);
            }
            WatchLogger.Log($"Ответ отправлен. Cтатус: {NoContent().StatusCode} /CategoryController/method: Delete");
            return NoContent();
        }
        #endregion
    }
}
