namespace ProductAPI.Domain.Entity.ProductDTO
{
    public record ProductDTO
    {
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
