using System.ComponentModel.DataAnnotations;
namespace ChefNDishes.Models;
public class Dish{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }
    [Required]
    [Range(1, Int32.MaxValue)]
    public int Calories { get; set; }

    [Display(Name="Chef's Name")]
    public int ChefId {get; set;}

    // Navigate Property
    public Chef? Creator { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
}