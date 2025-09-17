using System.ComponentModel.DataAnnotations;
using CRUDUsingEFCoreCodeFirstApproach.Models;

namespace CRUDUsingEFCoreCodeFirstApproach.Custom_Validations
{
    public class UsernameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var _dbContext = (ProductDbContext)validationContext.GetService(typeof(ProductDbContext));
            bool isUsernameExists = _dbContext.Users.Any(u => u.UserName == value.ToString());

            if (isUsernameExists)
            {
                return new ValidationResult("username already taken");

            }

            return ValidationResult.Success;
        }
    }
}
