using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;

public class Association{
    [Key]
    public int AssociationId { get;set; }
    [Required]
    public int ProductId { get;set; }
    [Required]
    public int CategoryId { get; set; }
    // Navigation Properties
    public Product? RelatedProduct {get; set;}
    public Category? RelatedCategory {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}