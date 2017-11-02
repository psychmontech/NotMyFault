using System.ComponentModel.DataAnnotations;

namespace NotMyFault.ViewModels
{
    public class CreateRecruitViewModel
    {
        [Required(ErrorMessage = "The role name is required"), MaxLength(40)]
        [Display(Name = "Name of the role")]
        public string NameOfTheRole { get; set; }

        [Required(ErrorMessage = "The role description is required"), MaxLength(1000)]
        [Display(Name = "Role description")]
        public string RoleDescription { get; set; }

        [Required(ErrorMessage = "The requirement description is required"), MaxLength(1000)]
        [Display(Name = "Requirement description")]
        public string RequirDescript { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        [Display(Name = "Candidate's Min credit")]
        public int MinCredit { get; set; }

        [Display(Name = "Max number of projects the candidate is working on")]
        public int MaxProjWkon { get; set; }

        public int ProjId { get; set; }
    }
}
