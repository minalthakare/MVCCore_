using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUDUsingEFCoreCodeFirstApproach.Custom_Validations;

namespace CRUDUsingEFCoreCodeFirstApproach.Models.Entities
{
    public class User
    {
       

        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter Your Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Name can be 3 to 20 char long")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Your UserName")]
        [MinLength(2,ErrorMessage ="User Name should be more than 2 char")]
        [MaxLength(20, ErrorMessage =" user name should not contain mire than 25 char")]
        [UsernameValidation]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Your Age")]
        [Range(1, 150, ErrorMessage ="age should be between 1 to 150")]

        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Your Email")]
        //[RegularExpression("", ErrorMessage ="Invalid Email")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        [EmailValidation]

        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Your Password")]
         [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$", ErrorMessage = "Weak Password")]
       // [DataType(DataType.Password, ErrorMessage ="Very weak Password")]

        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please ConfirmPassword")]
        [Compare("Password", ErrorMessage ="Password should Be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter Your DateOfBirth")]
        [DataType(DataType.Date, ErrorMessage ="Invalid Date")]
        [DateValidation]
        public DateTime DateOfBirth { get; set; }

    }
}
