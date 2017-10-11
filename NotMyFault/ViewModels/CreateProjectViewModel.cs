using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required(ErrorMessage = "The project name is required"), MaxLength(20)]
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

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Estimated valuation of the finished product")]
        public long Valuation { get; set; }

        [Display(Name = "Project visibility")]
        public int Visibility { get; set; }

        [Display(Name = "Work Repository Link")]
        public string RepoLink { get; set; }
    }
}
