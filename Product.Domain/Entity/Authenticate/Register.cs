namespace ProductAPI.Domain.Entity.Authenticate
{
    public class Register
    {
        [Required(ErrorMessage = "Введите имя пользователя.")]
        [StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Имя пользователя должено содержать не менее 2 символов.")]
        public string? UserName { get; set; }

        [StringLength(int.MaxValue, MinimumLength = 2, ErrorMessage = "Фамилия пользователя должено содержать не менее 2 символов.")]
        public string? UserSurname { get; set; }

        [Required(ErrorMessage = "Введите ник пользователя.")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Ник пользователя должен содержать не менее 6 символов.")]
        public string? Nickname { get; set; }

        [Required(ErrorMessage = "Введите пароль.")]
        [StringLength(int.MaxValue, MinimumLength = 8, ErrorMessage = "Пароль должен содержать не менее 8 символов.")]
        public string? Password { get; set; }

        [EmailAddress, Required(ErrorMessage = "Введите электронную почту.")]
        public string? Email { get; set; }
    }
}
