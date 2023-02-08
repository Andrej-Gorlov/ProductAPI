namespace ProductAPI.Domain.Entity.ImageDTO
{
    public record struct UpdateImageDTO
    {
        public UpdateImageDTO(int imageId, string imageUrl)
        {
            ImageId = imageId;
            ImageUrl = imageUrl;
        }

        [Required(ErrorMessage = "Укажите id изображения.")]
        public int ImageId { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
