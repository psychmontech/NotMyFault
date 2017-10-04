using System.ComponentModel.DataAnnotations;

namespace NotMyFault.ViewModels
{
    public class BuyerRegisterViewModel
    {
        [Required(ErrorMessage = "The user name is required"), MaxLength(20)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The nick name is required"), MaxLength(20)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The confirm email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Compare("Email", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company address")]
        public string CompanyAddr { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        public string ReturnUrl { get; set; }
    }
}
