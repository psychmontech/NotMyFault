using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class UpdateProjectViewModel
    {
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

        [Range(0, 100, ErrorMessage = "Please enter valid integer between 0 to 100")]
        [Display(Name = "Progress")]
        public int Progress { get; set; }

        [Display(Name = "Status")]
        public int Status { get; set; }
        public int ProjId { get; set; }
    }
}
