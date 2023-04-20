namespace ProductAPI.Domain.Entity.Authenticate
{
    public class Login
    {
        [Required(ErrorMessage = "Введите имя пользователя.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль.")]
        public string? Password { get; set; }
    }
}
