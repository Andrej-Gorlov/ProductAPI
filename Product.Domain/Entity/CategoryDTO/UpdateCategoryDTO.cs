namespace ProductAPI.Domain.Entity.CategoryDTO
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "Укажите id категории.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Укажите название категории.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина названия категории должна быть не менее 2 и не более 50 символов")]
        public string CategoryName { get; set; } = string.Empty;
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
