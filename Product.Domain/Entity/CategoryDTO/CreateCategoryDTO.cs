using Newtonsoft.Json;

namespace ProductAPI.Domain.Entity.CategoryDTO
{
    public record struct CreateCategoryDTO
    {
        public CreateCategoryDTO(int categoryId, string categoryName, string imageUrl)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            ImageUrl = imageUrl;
        }

        public int CategoryId { get; init; } 
        [Required(ErrorMessage = "Укажите название категории.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина названия категории должна быть не менее 2 и не более 50 символов")]
        public string CategoryName { get; init; } = string.Empty;
        //[StringLength(int.MaxValue,MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        //[Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; init; } = string.Empty;
    }
}
