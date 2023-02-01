namespace ProductAPI.Domain.Entity.ProductDTO
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        public string ProductName { get; set; } = string.Empty;

        [Range(0, 1000000000, ErrorMessage = "Цена не может быть меньше 0 и больше 1 000 000 000.")]
        public double Price { get; set; }
       
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }
        public CreateCategoryDTO? Category { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string MainImageUrl { get; set; } = string.Empty;
        public ICollection<CreateImageDTO>? SecondaryImages { get; set; }
    }
}
