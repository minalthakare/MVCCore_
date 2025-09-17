using System.ComponentModel.DataAnnotations;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Validations
{
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
          DateTime inputDate = (DateTime)value;

            if(inputDate> DateTime.Now)
            {
                return new ValidationResult("Date Of Brth cannot be greater Than todays date");
            }
             return ValidationResult.Success;

        }
    }
}
