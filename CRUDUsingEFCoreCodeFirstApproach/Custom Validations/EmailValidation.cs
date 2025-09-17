using System.ComponentModel.DataAnnotations;
using CRUDUsingEFCoreCodeFirstApproach.Models;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Validations
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _dbContext = (ProductDbContext)validationContext.GetService(typeof(ProductDbContext));

            bool alredyExist = _dbContext.Users.Any(u => u.Email ==  value.ToString());

            if (alredyExist)
            {
                return new ValidationResult("Alredy Exist");
            }
            return ValidationResult.Success;
        }
    }
}
