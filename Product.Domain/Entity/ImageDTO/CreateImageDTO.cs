namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record CreateImageDTO(
        [Required(ErrorMessage = "Укажите id продукта.")] int ProductId,
        [Required(ErrorMessage = "Укажите файл.")] IFormFile FileImage
    );
}

