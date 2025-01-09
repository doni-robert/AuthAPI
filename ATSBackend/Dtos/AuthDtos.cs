
namespace ATSBackend.Dtos
{
    // RegisterDto class represents the data required to register a new user
    public class RegisterDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }

    // LoginDto class represents the data required to log in a user
    public class LoginDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
