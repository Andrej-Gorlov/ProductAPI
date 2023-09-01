namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record struct ProductDTO
    {
        public ProductDTO(int productId, string productName, decimal price, 
            DateTime createDateTime, string description,string shortDescription,
            CategoryDTO.CategoryDTO category, string imageId, string imageUrl, 
            ICollection<ImageDTO.ImageDTO> secondaryImages)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
            CreateDateTime = createDateTime;
            Description = description;
            ShortDescription = shortDescription;
            Category = category;
            ImageId = imageId;
            ImageUrl = imageUrl;
            SecondaryImages = secondaryImages;
        }
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal Price { get; init; }
        public DateTime CreateDateTime { get; init; }
        public string Description { get; init; }
        public string ShortDescription { get; init; }
        public CategoryDTO.CategoryDTO? Category { get; init; }
        public string ImageId { get; init; }
        public string ImageUrl { get; init; }
        public ICollection<ImageDTO.ImageDTO>? SecondaryImages { get; init; }
    }
}
