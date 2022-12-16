namespace ProductAPI.Domain.Entity.ImageDTO
{
    public class CreateImageDTO
    {
        [Required(ErrorMessage = "Введите ID продукта.")]
        public int ProductId { get; set; }
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Длина url адреса должна быть не менее 5 символов")]
        [Url(ErrorMessage = "Не веерно введен url адрес")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
