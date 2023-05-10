using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeddingPlanner.Validations;

namespace WeddingPlanner.Models;

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
    public List<Wedding> PlannedWedding {get; set;} = new List<Wedding>();
    public List<Attend> ReserveWedding {get; set;} = new List<Attend>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}