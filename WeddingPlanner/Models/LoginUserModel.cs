using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class LoginUser{
    // No other fields!
    [Required]
    [Display(Name="Email")] 
    public string? LoginEmail { get; set; }
    [Required]
    [Display(Name="Password")]
    public string? LoginPassword { get; set; }
}
