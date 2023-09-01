namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record struct ImageDTO
    {
        public ImageDTO(string imageId, int productId, string imageUrl)
        {
            ImageId = imageId;
            ProductId = productId;
            ImageUrl = imageUrl;
        }
        public string ImageId { get; init; }
        public int ProductId { get; init; }
        public string ImageUrl { get; init; }
    }
}
