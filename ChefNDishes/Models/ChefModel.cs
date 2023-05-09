using System.ComponentModel.DataAnnotations;
using ChefNDishes.Validations;
namespace ChefNDishes.Models;
public class Chef{
    [Key]
    public int ChefId { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }
    [Required]
    [FutureDate]
    [Display(Name="Date of Birth")]
    public DateTime? DoB { get; set; }
    public List<Dish> Dishes { get; set; } = new List<Dish>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}