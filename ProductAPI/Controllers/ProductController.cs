using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using ProductAPI.Domain.Paging;

namespace ProductAPI.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersionNeutral]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productSer;
        public ProductController(IProductService productSer) => _productSer = productSer;

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
        [ResponseCache(CacheProfileName = "Default30")]
        [Route("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] PagingQueryParameters paging, [FromQuery] string? filter, [FromQuery] string? search)
        {
            WatchLogger.Log($"выполнен вход. /ProductController/method: Get");
            IBaseResponse<PagedList<ProductDTO>>? products = null;

            if (!(filter is null) && !(search is null))
            {
                WatchLogger.Log($"Получение списка продуктов по фильтру: {filter} и поиску: {search}.");
                products = await _productSer.GetServiceAsync(paging, filter, search);
            }
            else if (!(filter is null) && search is null)
            {
                WatchLogger.Log($"Получение списка продуктов по фильтру: {filter}.");
                products = await _productSer.GetServiceAsync(paging, filter);
            }
            else if (filter is null && !(search is null))
            {
                WatchLogger.Log($"Получение списка продуктов по поиску: {search}.");
                products = await _productSer.GetServiceAsync(paging, search: search);
            }
            else if (filter is null && search is null)
            {
                WatchLogger.Log($"Получение списка продуктов.");
                products = await _productSer.GetServiceAsync(paging);
            }

            if (products.Result is null)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Get");
                return NotFound(products);
            }
            WatchLogger.Log($"Получение метаданных пагинации.");
            var metadata = new
            {
                products.Result.TotalCount,
                products.Result.PageSize,
                products.Result.CurrentPage,
                products.Result.TotalPages,
                products.Result.HasNext,
                products.Result.HasPrevious
            };
            WatchLogger.Log($"Добавление метаданных в заголовок запроса.");
            Response?.Headers?.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Get");
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
            WatchLogger.Log($"выполнен вход. /ProductController/method: GetById");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. id: [{id}] не может быть меньше или равно нулю. статус: {NotFound().StatusCode} /ImageController/method: GetById");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Получение продукта по id: {id}.");
            var product = (BaseResponse<ProductDTO>)await _productSer.GetByIdServiceAsync(id);
            if (product.Status is Status.NotFound)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: GetById");
                return NotFound(product);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: GetById");
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
        /// </remarks>
        /// <response code="201"> Продукт создан. </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        [HttpPost]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO productDTO)
        {
            WatchLogger.Log($"выполнен вход. /ProductController/method: Create");
            WatchLogger.Log($"Создание нового продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.CreateServiceAsync(productDTO);
            if (product.Status is Status.ExistsName)
            {
                ModelState.AddModelError("", "Продукт с таким наименованием существует.");
                WatchLogger.Log($"Ответ отправлен. Продукт с таким наименованием существует. Статус: {BadRequest().StatusCode} /ImageController/method: Create");
                return BadRequest(ModelState);
            }
            if (product.Status is Status.ExistsUrl)
            {
                ModelState.AddModelError("", "Продукт с таким url адрессом изображения существует.");
                WatchLogger.Log($"Ответ отправлен. Продукт с таким url адрессом изображения существует. Статус: {BadRequest().StatusCode} /ImageController/method: Create");
                return BadRequest(ModelState);
            }
            if (product.Status is Status.NotCreate)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Create");
                return BadRequest(product);
            }
            WatchLogger.Log($"Ответ отправлен. статус: 201 /ProductController/method: Create");
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
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Продукт не найден. </response>
        [HttpPut]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO productDTO)
        {
            WatchLogger.Log($"выполнен вход. /ProductController/method: Update");
            WatchLogger.Log($"Обновление продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.UpdateServiceAsync(productDTO);
            if (product.Status is Status.NotFound)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Update");
                return NotFound(product);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Update");
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
        /// </remarks>
        /// <response code="200"> Запрос прошёл. (Успех) </response>
        /// <response code="400"> Введены недопустимые данные. </response>
        /// <response code="404"> Продукт не найден. </response>
        [HttpPatch]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePatrial(int id, JsonPatchDocument<UpdatePatrialProductDTO> productDto)
        {
            WatchLogger.Log($"выполнен вход. /ProductController/method: UpdatePatrial");
            if (productDto.Operations.FirstOrDefault(x => x.op == "replace") != null)
            {
                ///////запрещино 
            }
            if (productDto is null || id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {BadRequest().StatusCode} /ProductController/method: UpdatePatrial");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Частичное обновление продукта.");
            var product = (BaseResponse<ProductDTO>)await _productSer.UpdatePatrialServiceAsync(id, productDto);
            if (product.Status is Status.NotFound)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: UpdatePatrial");
                return NotFound(product);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: UpdatePatrial");
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
        ///        Id: 0   // Введите id продукта, которого нужно удалить.
        ///     
        /// </remarks>
        /// <response code="204"> Продукт удалён. (нет содержимого) </response>
        /// <response code="400"> Недопустимое значение ввода </response>
        /// <response code="404"> Продукт c указанным id не найден. </response>
        [HttpDelete]
        [Route("product/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            WatchLogger.Log($"выполнен вход. /ProductController/method: Delete");
            if (id <= 0)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {BadRequest().StatusCode} /ProductController/method: Delete");
                return BadRequest($"id: [{id}] не может быть меньше или равно нулю");
            }
            WatchLogger.Log($"Удаление продукта.");
            var product = await _productSer.DeleteServiceAsync(id);
            if (product.Result is false)
            {
                WatchLogger.Log($"Ответ отправлен. статус: {NotFound().StatusCode} /ProductController/method: Delete");
                return NotFound(product);
            }
            WatchLogger.Log($"Ответ отправлен. статус: {Ok().StatusCode} /ProductController/method: Delete");
            return NoContent();
        }
        #endregion
    }
}
