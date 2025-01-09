using Microsoft.AspNetCore.Identity;

namespace ATSBackend.Entities;

// User class represents a custom user entity that extends IdentityUser
// IdentityUser already includes common user properties such as UserName, Email, PasswordHash, etc
public class User : IdentityUser
{

}