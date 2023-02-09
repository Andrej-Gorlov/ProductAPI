namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record struct CreateImageDTO
    {
        public CreateImageDTO(int productId, string imageUrl)
        {
            ProductId = productId;
            ImageUrl = imageUrl;
        }

        public int ProductId { get; init; }
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; init; } = string.Empty;
    }
}
