using System.ComponentModel.DataAnnotations;

namespace Quests.Application.UserDirectory.AuthenticateUser;

public class AuthenticateUserRequest
{
    [Required (ErrorMessage = "Email is required.")]
    public string Email { get; set; }
    
    [Required (ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}