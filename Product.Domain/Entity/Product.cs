﻿namespace ProductAPI.Domain.Entity
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } =string.Empty;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public string ImageId { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public IList<Image>? SecondaryImages { get; set; }
    }
}
