using System.ComponentModel.DataAnnotations;

namespace Quests.Application.UserDirectory.AddUser;

public class AddUserRequest
{
    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "The password and confirmation password don't match.")]
    public string ConfirmPassword { get; set; }
}