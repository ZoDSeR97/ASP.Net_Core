using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Validations;
public class FutureDateAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)    
    {        
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if(value != null)
            if(DateTime.Compare((DateTime)value, DateTime.Today)<0){
                TimeSpan age = DateTime.Now-(DateTime)value;
                int years = (int)(age.TotalDays/365.25);
                if(years < 18)
                    return new ValidationResult("Does not meet minimum 18!");
                return ValidationResult.Success;
            }
        return new ValidationResult("Date is not in the past");
    }
}
