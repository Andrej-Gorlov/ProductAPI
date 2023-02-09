namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record struct ProductDTO
    {
        public ProductDTO(int productId, string? productName, double price, DateTime createDateTime, string description, CategoryDTO.CategoryDTO? category, string mainImageUrl, ICollection<ImageDTO.ImageDTO>? secondaryImages)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            CreateDateTime = createDateTime;
            Description = description;
            Category = category;
            MainImageUrl = mainImageUrl;
            SecondaryImages = secondaryImages;
        }

        public int ProductId { get; init; }
        public string? ProductName { get; init; } = string.Empty;
        public double Price { get; init; }
        public DateTime CreateDateTime { get; init; } = DateTime.Now;
        public string Description { get; init; } = string.Empty;
        //public int CategoryId { get; init; }
        public CategoryDTO.CategoryDTO? Category { get; init; }
        public string MainImageUrl { get; init; } = string.Empty;
        public ICollection<ImageDTO.ImageDTO>? SecondaryImages { get; init; }
    }
}
