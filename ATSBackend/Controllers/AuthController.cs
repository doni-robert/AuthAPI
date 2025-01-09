using ATSBackend.Dtos;
using ATSBackend.Entities;
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
        
        // Constructor to inject dependencies for UserManager and SignInManager services
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                return Ok("User registered successfully.");
            }
            // If there were errors during user creation, return them
            return BadRequest(result.Errors);
        }

    }
}
