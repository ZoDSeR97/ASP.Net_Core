using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Product{
    [Key]
    public int ProductId { get;set; }
    [Required]
    public string? Name { get;set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public double? Price { get; set; }
    // Navigation Property
    public List<Association> RelatedCategories {get; set;} = new List<Association>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}