namespace ProductAPI.Domain.Entity.CategoryDTO
{
    public record struct CategoryDTO
    {
        public CategoryDTO(int categoryId, string categoryName, string imageUrl)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            ImageUrl = imageUrl;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
