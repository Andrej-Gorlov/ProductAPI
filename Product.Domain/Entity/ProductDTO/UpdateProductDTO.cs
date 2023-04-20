namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record struct UpdateProductDTO
    {
        public UpdateProductDTO(int productId, string productName, double price, string description,string shortDescription, int categoryId, UpdateCategoryDTO? category, string mainImageUrl, ICollection<UpdateImageDTO>? secondaryImages)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Description = description;
            ShortDescription = shortDescription;
            CategoryId = categoryId;
            Category = category;
            MainImageUrl = mainImageUrl;
            SecondaryImages = secondaryImages;
        }

        [Required(ErrorMessage = "Укажите id продукта.")]
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Введите название продукта.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Название продукта должен содержать быть не менее 2 и не более 150 символов")]
        public string ProductName { get; init; } = string.Empty;

        [Range(0, 1000000000, ErrorMessage = "Цена не может быть меньше 0 и больше 1 000 000 000.")]
        public double Price { get; init; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Описание продукта не должно превышать 1000 символов.")]
        public string Description { get; init; } = string.Empty;
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Краткое описание продукта не должно превышать 250 символов.")]
        public string ShortDescription { get; set; }
        public int CategoryId { get; set; }
        public UpdateCategoryDTO? Category { get; init; }

        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string MainImageUrl { get; init; } = string.Empty;
        public ICollection<UpdateImageDTO>? SecondaryImages { get; init; }
    }
}
