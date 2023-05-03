using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class Date{
    [Required]
    [FutureDate]
    public DateTime? D {get; set;}
}

public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)    
    {        
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if(value != null)
            if(DateTime.Compare((DateTime)value, DateTime.Today)<0)
                return ValidationResult.Success;
        return new ValidationResult("Date is not in the past");
    }
}
