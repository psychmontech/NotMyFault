using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ViewRecruitViewModel
    {
        public Project MyProj { get; set; }
        public string NameOfTheRole { get; set; }
        public string RoleDescription { get; set; }
        public string RequirDescript { get; set; }
        public int MaxNumPrjWkOn { get; set; }
        public int MinCredit { get; set; }
        public bool IsOpen { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Developer> Candidates { get; set; }
        public int RecruitId { get; set; }
        public Developer CurrentDev { get; set; }
        public bool CurrentDevIsLeader { get; set; }
        public bool CurrentDevIsInvolved { get; set; }
        public bool CurrentDevHasApplied { get; set; }
        public bool CurrentDevIsEligibleToApply { get; set; }
    }
}
