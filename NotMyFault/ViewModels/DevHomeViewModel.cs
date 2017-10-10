using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System.Collections.Generic;

    namespace NotMyFault.ViewModels
{
    public class DevHomeViewModel
    {
        public ICollection<Project> MyInvolvedProjects { get; set; }
        public ICollection<Project> MyLeadingProjects { get; set; }
        public ICollection<Project> MyFollowingProjects { get; set; }
        public Interview MyComingupIntws { get; set; }
        public ICollection<Endorsment> MyEndors{ get; set; }
    }
}
