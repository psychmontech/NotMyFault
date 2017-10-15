using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class SearchProjectsViewModel
    {
        public ICollection<Project> Projects { get; set; }
        public int SortBy { get; set; }
        public int Status { get; set; }
        public string words { get; set; }

    }
}
