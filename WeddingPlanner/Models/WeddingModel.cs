using System.ComponentModel.DataAnnotations;
using WeddingPlanner.Validations;
namespace WeddingPlanner.Models;

public class Wedding{
    [Key]
    public int WeddingId { get;set; }
    [Required]
    public string? WedderOne { get;set; }
    [Required]
    public string? WedderTwo { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [FutureDate]
    public DateTime? Date { get; set; }
    [Required]
    public string? Address { get; set; }
    public int UserId {get; set;}

    public List<Attend> Guests {get; set;} = new List<Attend>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}