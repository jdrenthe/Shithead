using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shithead.Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public List<UserFriend> Friends { get; set; }

        public List<Notification> Notifications { get; set; }

        public NotificationSubscription NotificationSubscription { get; set; }

        [Required(ErrorMessage = "Enter a name.")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Enter a valid name.")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Use only letters.")]
        public string UserName { get; set; }

        [StringLength(70, MinimumLength = 0, ErrorMessage = "Enter a last name.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter an email address.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        [Required(ErrorMessage = "Enter an image.")]
        public string Image
        {
            get => string.IsNullOrEmpty(_image) ? "/img/user-stock.jpeg" : _image;
            set => _image = value;
        }
        private string _image;

        public DateTime Created { get; set; }

        public bool Blocked { get; set; }

        #region NotMapped

        [NotMapped]
        [Required(ErrorMessage = "Enter a valid password.")]
        [StringLength(70, MinimumLength = 8, ErrorMessage = "Password needs a minimum of 8 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "The password must consist of at least 1 capital letter and 1 unique character.")]
        public string Password { get; set; }

        [NotMapped]
        public Credentials Credentials { get; set; }

        [NotMapped]
        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions.")]
        public bool Conditions { get; set; }

        [NotMapped]
        public Email HtmlEmail { get; set; }

        #endregion
    }
}
