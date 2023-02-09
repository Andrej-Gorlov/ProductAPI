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

        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string ImageUrl { get; init; } = string.Empty;
    }
}
