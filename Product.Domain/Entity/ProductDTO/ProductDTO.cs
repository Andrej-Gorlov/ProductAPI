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

        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreateDateTime { get; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        //public int CategoryId { get; set; }
        public CategoryDTO.CategoryDTO? Category { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public ICollection<ImageDTO.ImageDTO>? SecondaryImages { get; set; }
    }
}
