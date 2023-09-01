namespace ProductAPI.Domain.Entity
{
    public class Image 
    {
        [Key]
        public string ImageId { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
