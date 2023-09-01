namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record UpdateProductDTO(

        [Required(ErrorMessage = "Укажите id продукта.")]
        int ProductId,

        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        string ProductName,

        [Range(0, 1000000000, ErrorMessage = "Цена не может быть меньше 0 и больше 1 000 000 000.")]
        decimal Price,

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        string? Description,

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Краткое описание продукта не должно превышать 250 символов.")]
        string? ShortDescription,

        int CategoryId,

        #region Main image
        string? ImageId,
        IFormFile? FileMainImage,
        #endregion

        #region Secondary images
        IList<string>? SecondaryImagesId,
        IList<IFormFile>? FileSecondaryImages
        #endregion
    );
}
