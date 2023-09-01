namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record UpdateImageDTO(
        [Required(ErrorMessage = "Укажите id продукта.")] int ProductId,
        [Required(ErrorMessage = "Укажите id изображения.")]string ImageId,
        [Required(ErrorMessage = "Укажите файл.")]IFormFile FileImage
    );
}
