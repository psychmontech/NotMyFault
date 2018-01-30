using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required(ErrorMessage = "The project name is required"), MaxLength(40)]
        [Display(Name = "Project name")]
        public string ProjName { get; set; }

        [Required(ErrorMessage = "The brief description is required"), MaxLength(100)]
        [Display(Name = "Project brief description")]
        public string BriefDescript { get; set; }

        [Required(ErrorMessage = "The full description is required"), MaxLength(1000)]
        [Display(Name = "Full description")]
        public string FullDescript { get; set; }

        [Required(ErrorMessage = "The projected complete date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Projected complete date")]
        public DateTime ProtdCompDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid bitcoin value")]
        [Display(Name = "Expecting value in bitcoins")]
        public double Value_bitcoin { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid ethereum value")]
        [Display(Name = "Expecting value in ethereum")]
        public double Value_ethereum { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid litecoin value")]
        [Display(Name = "Expecting value in litecoin")]
        public double Value_litecoin { get; set; }

        [Display(Name = "Project visibility")]
        public int Visibility { get; set; }

        [Display(Name = "Work Repository Link")]
        public string RepoLink { get; set; }

        [Range(0, 100, ErrorMessage = "Please enter valid integer between 0 to 100")]
        [Display(Name = "Progress")]
        public int Progress { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }
        public int ProjId { get; set; }
    }
}
