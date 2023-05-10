using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Attend{
    [Key]
    public int AttendId { get;set; }
    [Required]
    public int UserId { get;set; }
    [Required]
    public int WeddingId {get; set;}
    //Navigation Properties
    public User? User {get; set;}
    public Wedding? Wedding {get; set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}