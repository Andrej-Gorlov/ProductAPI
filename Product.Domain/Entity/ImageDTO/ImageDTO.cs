namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record struct ImageDTO
    {
        public ImageDTO(int imageId, int productId, string imageUrl)
        {
            ImageId = imageId;
            ProductId = productId;
            ImageUrl = imageUrl;
        }

        public int ImageId { get; init; }
        public int ProductId { get; init; }
        public string ImageUrl { get; init; } = string.Empty;
    }
}
