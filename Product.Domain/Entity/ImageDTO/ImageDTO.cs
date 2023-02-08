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

        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
