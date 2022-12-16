namespace ProductAPI.Domain.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public string MainImageUrl { get; set; } = string.Empty;
        public ICollection<Image>? SecondaryImages { get; set; }
    }
}
