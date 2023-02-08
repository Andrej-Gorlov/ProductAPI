namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record ImageDTO
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
