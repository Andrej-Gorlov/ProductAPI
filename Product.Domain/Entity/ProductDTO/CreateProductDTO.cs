namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record struct CreateProductDTO
    {
        public CreateProductDTO(string productName, double price, string description, int categoryId, CreateCategoryDTO? category, string mainImageUrl, ICollection<CreateImageDTO>? secondaryImages)
        {
            ProductName = productName;
            Price = price;
            Description = description;
            CategoryId = categoryId;
            Category = category;
            MainImageUrl = mainImageUrl;
            SecondaryImages = secondaryImages;
        }

        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        public string ProductName { get; init; } = string.Empty;

        [Range(0, 1000000000, ErrorMessage = "Цена не может быть меньше 0 и больше 1 000 000 000.")]
        public double Price { get; init; }
       
        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        public string Description { get; init; } = string.Empty;

        public int CategoryId { get; init; }
        public CreateCategoryDTO? Category { get; init; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string MainImageUrl { get; init; } = string.Empty;
        public ICollection<CreateImageDTO>? SecondaryImages { get; init; }
    }
}
