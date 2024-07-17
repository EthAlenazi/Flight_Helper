namespace WebAPI.Models
{
    public class AuthenticationDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }


    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
    }

    public class StaticCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
