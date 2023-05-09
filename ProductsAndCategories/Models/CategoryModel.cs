using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Category{
    [Key]
    public int CategoryId { get;set; }
    [Required]
    public string? Name { get;set; }
    // Navigation Property
    public List<Association> RelatedProducts {get; set;} = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}