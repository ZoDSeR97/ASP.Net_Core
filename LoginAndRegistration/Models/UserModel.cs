using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoginAndRegistration.Validations;

namespace LoginAndRegistration.Models;

public class User{
    [Key]
    public int UserId { get; set; }

    [Required]
    [MinLength(2)]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(2)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string? Password { get; set; }

    [Required]
    [NotMapped]
    [Compare("Password")]
    public string? PasswordConfirm { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}