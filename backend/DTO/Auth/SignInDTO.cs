using System.ComponentModel.DataAnnotations;

namespace backend.DTO.Auth;

public class SignInDTO
{
    [Required(ErrorMessage = "Login is required")]
    public string Login { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}