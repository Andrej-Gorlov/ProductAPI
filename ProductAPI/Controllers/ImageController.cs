﻿namespace ProductAPI.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersionNeutral]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageSer;
        public ImageController(IImageService imageSer) => _imageSer = imageSer;

        #region Get
        /// <summary>
        /// Список изображений (возможно приминение фильра по id продукта и поиска).
        /// </summary>
        /// <param name="filter">Фильтр</param>
        /// <param name="search">Поиск</param>
        /// <returns>Вывод изображений</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /images
        ///     
        ///        idProduct: id категории    // Введите значение id продукта (Необязательно).
        ///        search: Поиск              // Введите значение поиска (Необязательно).
        ///        
        /// </remarks> 
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="404"> Список изображений не найден. </response>
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default30")]
        [Route("images")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] string? filter, [FromQuery] string? search)
        {
            WatchLogger.Log($"выполнен вход. /ImageController/method: Get");
            IBaseResponse<List<ImageDTO>> immages;
            if (!(filter is null) && !(search is null))
            {
                WatchLogger.Log($"Получение списка изображений по фильтру: {filter} и поиску: {search}.");
                immages = await _imageSer.GetServiceAsync(filter, search);
            }
            else if (!(filter is null) && (search is null))
            {
                WatchLogger.Log($"Получение списка изображений по фильтру: {filter}.");
                immages = await _imageSer.GetServiceAsync(filter);
            }
            else if (filter is null && !(search is null))
            {
                WatchLogger.Log($"Получение списка изображений по поиску: {search}.");
                immages = await _imageSer.GetServiceAsync(search: search);
            }
            else
            {
                WatchLogger.Log($"Получение списка изображений.");
                immages = await _imageSer.GetServiceAsync();
            }
            if (immages.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ImageController/method: Get");
                return NotFound(immages);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ImageController/method: Get");
            return Ok(immages);
        }
        #endregion

        #region GetById
        /// <summary>
        /// Вывод изображения по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Вывод данных изображения</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     GET /image/{id:int}
        ///     
        ///        Id: 0   // Введите id изображения, которую нужно показать.
        ///     
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Изображение не найдено </response>
        [HttpGet]
        [ResponseCache(Duration = 120)]
        [Route("image/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            WatchLogger.Log($"выполнен вход. /ImageController/method: GetById");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. id: [{id}] не может быть меньше или равно нулю. статус: {NotFound().StatusCode} /ImageController/method: GetById");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Получение изображения по id: {id}.");
            var image = await _imageSer.GetByIdServiceAsync(id);
            if (image.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ImageController/method: GetById");
                return NotFound(image);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ImageController/method: GetById");
            return Ok(image);
        }
        #endregion

        #region Create
        /// <summary>
        /// Создание нового изображения.
        /// </summary>
        /// <param name="imageDTO"></param>
        /// <returns>Создаётся изображения</returns>
        /// <remarks>
        /// 
        ///     POST /image   
        ///     
        /// </remarks>
        /// <response code="201"> Изображение создано. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        [HttpPost]
        [Route("image")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateImageDTO imageDTO)
        {
            WatchLogger.Log($"выполнен вход. /ImageController/method: Create");
            WatchLogger.Log($"Создание нового изображения.");
            var image = (BaseResponse<ImageDTO>)await _imageSer.CreateServiceAsync(imageDTO);
            if (image.Status is Status.ExistsUrl)
            {
                ModelState.AddModelError("", "Изображение с таким url существует.");
                WatchLogger.Log($"Ответ отправлен. Изображение с таким url существует. Статус: {BadRequest().StatusCode} /ImageController/method: Create");
                return BadRequest(ModelState);
            }
            if (image.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ImageController/method: Create");
                return BadRequest(image);
            }
            WatchLogger.Log($"Ответ отправлен. статус: 201 /ImageController/method: Create");
            return CreatedAtAction(nameof(Get), image);
        }
        #endregion

        #region Update
        /// <summary>
        /// Обновление изображения.
        /// </summary>
        /// <param name="imageDTO"></param>
        /// <returns>Обновление изображения.</returns>
        /// <remarks>
        ///
        ///     PUT /image
        ///
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Изображение не найдено. </response>
        [HttpPut]
        [Route("image")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateImageDTO imageDTO)
        {
            WatchLogger.Log($"выполнен вход. /ImageController/method: Update");
            WatchLogger.Log($"Обновление изображения.");
            var image = await _imageSer.UpdateServiceAsync(imageDTO);
            if (image.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ImageController/method: Update");
                return NotFound(image);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ImageController/method: Update");
            return Ok(image);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Удаление изображения.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Изображение удаляется.</returns>
        /// <remarks>
        /// Образец запроса:
        /// 
        ///     DELETE /image/{id}
        ///     
        ///        Id: 0   // Введите id изображения, которое нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Изображение удалёно. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Изображение c указанным id не найдено. </response>
        [HttpDelete]
        [Route("image/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            WatchLogger.Log($"выполнен вход. /ImageController/method: Delete");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {BadRequest().StatusCode} /ImageController/method: Delete");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Удаление изображения.");
            var image = await _imageSer.DeleteServiceAsync(id);
            if (image.Result is false)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ImageController/method: Delete");
                return NotFound(image);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ImageController/method: Delete");
            return NoContent();
        }
        #endregion
    }
}
