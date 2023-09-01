namespace ProductAPI.Domain.Entity.CategoryDTO
{
    public record struct CategoryDTO  
    {
        public CategoryDTO(int categoryId, string categoryName, string imageUrl, string imageId, string description)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            ImageUrl = imageUrl;
            ImageId = imageId;
            Description = description;
        }
        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        #region Image
        public string ImageId { get; init; } = string.Empty;
        public string ImageUrl { get; init; } = string.Empty;
        #endregion
    }
}
