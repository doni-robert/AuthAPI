using System.Reflection.Metadata.Ecma335;
using ATSBackend.Dtos;
using ATSBackend.Entities;
using ATSBackend.Services;

// using ATSBackend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ATSBackend.Controllers
{
    // AuthController for handling user authentication and authorization
    [ApiController]
    [Route("api/[controller]")] // The base route for this controller's endpoints (/api/auth)
    public class AuthController : ControllerBase
    {
        // Private fields for UserManager and SignInManager services
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;

        // private readonly IEmailSender _emailSender;
        
        // Constructor to inject dependencies for UserManager and SignInManager services
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            // _emailSender = emailSender;
        }

        // Register endpoint for handling user registration
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            // Check if password and confirmpassword match
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Password and confirm password do not match.");
            }

            // Check if the user already exists
            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                return BadRequest("User already exists.");
            }

            // Create a new User object with the provided details
            var user = new User { UserName = model.UserName, Email = model.Email };

            // Attempt to create the user in the database
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Generate a JWT token for the authenticated user
                var token = _tokenService.GenerateToken(user.UserName);
                // Return the token in the response
                return Ok(new { token });
            }
            // If there were errors during user creation, return them
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            // Find the user by their email address from the database
            var user = await _userManager.FindByEmailAsync(model.Email);

            // Check if the user exists
            if (user == null)
            {
                return Unauthorized("Invalid Credentials");
            }

            // Attempt to sign in the user with the provided password
            // isPersistent is set to false, and lockoutOnFailure is also false
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            // Check if the sign-in attempt was successful
           if (result.Succeeded)
            {
                // Generate a JWT token for the authenticated user
                var token = _tokenService.GenerateToken(user.UserName);
                // Return the token in the response
                return Ok(new { token });
            }

            // Return an Unauthorized response if the sign-in attempt failed
            return Unauthorized("Invalid login attempt");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to reset password");
            }

            return Ok("Password has been reset successfully");
        }

        // [HttpPost("password-recovery")]
        // public async Task<IActionResult> PasswordRecovery([FromBody] PasswordRecoveryDto model)
        // {
        //     var user = await _userManager.FindByEmailAsync(model.Email);
        //     if (user == null)
        //     {
        //         return BadRequest("Email not found");
        //     }

        //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //     var resetLink = Url.Action("ResetPassword", "Auth", new { token, email = user.Email }, Request.Scheme);

        //     await _emailSender.SendEmailAsync(user.Email, "Password Recovery", 
        //         $"Click <a href='{resetLink}'>here</a> to reset your password.");

        //     return Ok("Password recovery email sent.");
        // }

    }
}
