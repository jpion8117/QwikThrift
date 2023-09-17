#nullable disable
using System.ComponentModel.DataAnnotations;

namespace QwikThrift.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please enter your username to continue...")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please enter your password to continue...")]
        public string Password { get; set; }
    }
}
