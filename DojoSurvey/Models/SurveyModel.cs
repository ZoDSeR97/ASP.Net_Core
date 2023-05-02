using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models;
public class Survey{
    // Each property in a model gets its own set of DataAnnotations
    // Each annotation applies only to the property that is directly below it
    [Required]
    // We can stack annotations to apply multiple requirements to one property
    // In this case, a name is required but must also be at least 2 characters long 
    [MinLength(2)]
    public string? name {get; set;}
    
    [Required]
    public string? location {get; set;}
    
    [Required]
    public string? favLang {get; set;}
    
    [MinLength(20, ErrorMessage="The comment need to have at least 20 characters")]
    public string? comment {get; set;}
}