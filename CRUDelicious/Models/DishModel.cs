using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;

public class Dish{
    [Key]
    public int DishId {get;set;}
    
    [Required]
    [MaxLength(45)]
    [MinLength(2)]
    [Display(Name="Name of Dish")]
    public string? Name {get; set;}

    [Required]
    [MaxLength(45)]
    [MinLength(2)]
    [Display(Name="Chef's Name")]
    public string? Chef {get; set;}
    
    [Required]
    [Range(1,5)]
    public int? Tastiness {get; set;}
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage="Calories must be greater than 0, no water here!")]
    [Display(Name="# of Calories")]
    public int? Calories {get; set;}

    [Required]
    public string? Description {get; set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}