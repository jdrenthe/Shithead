using System.ComponentModel.DataAnnotations;

namespace Shithead.Shared.Models.Forms
{
    public class PassswordReset
    {
        [Required(ErrorMessage = "Enter a email address.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }
    }
}
