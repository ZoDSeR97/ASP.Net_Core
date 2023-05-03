using System.ComponentModel.DataAnnotations;

namespace SessionWorkShop.Models;

public class User{
    [Required]
    [MinLength(2)]
    protected static Random rng = new Random();
    public string name {get; set;} = "";
    public int num {get; set;} = rng.Next();
}