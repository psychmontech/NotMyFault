using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class SearchRecruitViewModel // this viewmodel is shared by SearchRecruit and ListRecruits
    {
        public ICollection<Recruitment> Recruits { get; set; }
        public string KeyWords { get; set; }
    }
}
