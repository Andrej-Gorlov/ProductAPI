namespace ProductAPI.Domain.Entity.Authenticate
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? Nickname { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
    }
}
