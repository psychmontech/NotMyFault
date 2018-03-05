using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class SearchProjectsViewModel
    {
        public ICollection<Project> Projects { get; set; }
        [Display(Name = "Sort By")]
        public int SortBy { get; set; }
        [Display(Name = "Project status")]
        public int StatusFilter { get; set; }
        public string KeyWords { get; set; }
        public User CurrentUser { get; set; }
    }
}
