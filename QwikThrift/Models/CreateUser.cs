#nullable disable
using System.ComponentModel.DataAnnotations;

namespace QwikThrift.Models
{
    public class CreateUser : UserLogin
    {
        [Required(ErrorMessage = "Please enter your email address...")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password...")]
        [Compare("Password", ErrorMessage = "Passwords do not match. Please try again...")]
        public string ConfirmPassword { get; set; }
    }
}
