using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class EditUserProfileViewModel
    {
        public int Role { get; set; }

        [Required(ErrorMessage = "The nick name is required"), MaxLength(20)]
        [Display(Name = "Nick name")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company address")]
        public string CompanyAddr { get; set; }

        [Display(Name = "Bitcoin wallet address")]
        [StringLength(34, MinimumLength = 34, ErrorMessage = "invalid bitcoin wallet address")]
        public string BitcoinAddr { get; set; }

        [Display(Name = "Ethereum wallet address")]
        [StringLength(40, MinimumLength = 40, ErrorMessage = "invalid ethereum wallet address")]
        public string EthereumAddr { get; set; }

        [Display(Name = "Litecoin wallet address")]
        [StringLength(34, MinimumLength = 34, ErrorMessage = "invalid litecoin wallet address")]
        public string LitecoinAddr { get; set; }

        [MaxLength(400)]
        [Display(Name = "Self introduction, skills etc")]
        public string SelfIntro { get; set; }
    }
}
