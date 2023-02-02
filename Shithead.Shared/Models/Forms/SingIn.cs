using System.ComponentModel.DataAnnotations;

namespace Shithead.Shared.Models.Forms
{
    public class SingIn
    {
        [Required(ErrorMessage = "Enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255, MinimumLength = 1)]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a valid password.")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "Password needs a minimum of 8 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "The password must consist of at least 1 capital letter and 1 unique character.")]
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
