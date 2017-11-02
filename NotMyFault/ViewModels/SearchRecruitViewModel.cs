using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class SearchRecruitViewModel
    {
        public ICollection<Recruitment> Recruits { get; set; }
    }
}
