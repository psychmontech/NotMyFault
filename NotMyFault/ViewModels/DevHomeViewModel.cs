using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System.Collections.Generic;

namespace NotMyFault.ViewModels
{
    public class DevHomeViewModel
    {
        public List<Project> MyInvolvedProjects { get; set; }
        public List<Project> MyLeadingProjects { get; set; }
        public List<Project> MyWatchingProjects { get; set; }
        public Interview MyComingupIntws { get; set; }
        public List<Endorsment> MyEndors{ get; set; }
        public int MyCredits { get; set; } 
    }
}
