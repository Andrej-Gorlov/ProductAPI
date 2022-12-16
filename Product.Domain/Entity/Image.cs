namespace ProductAPI.Domain.Entity
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
