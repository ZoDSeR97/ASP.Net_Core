using System.ComponentModel.DataAnnotations;

public class LoginUser
{
    // No other fields!
    [Required]    
    public string? LoginEmail { get; set; } 
    [Required]    
    public string? LoginPassword { get; set; } 
}
