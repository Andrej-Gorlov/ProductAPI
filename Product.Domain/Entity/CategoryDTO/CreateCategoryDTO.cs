namespace ProductAPI.Domain.Entity.CategoryDTO
{
    public record CreateCategoryDTO(
    
        [Required(ErrorMessage = "Укажите название категории.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина названия категории должна быть не менее 2 и не более 50 символов")]
        string CategoryName,

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 200 символов.")]
        string? Description,

        IFormFile Image
    );
}
