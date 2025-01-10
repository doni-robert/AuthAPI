
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
    
    // PasswordRecoveryDto class represents the data required to request a password recovery
    public class PasswordRecoveryDto
    {
        public required string Email { get; set;}
    }
    
    // ResetPasswordDto class represents the data required to reset the user's password
    public class ResetPasswordDto
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }

    }
}
