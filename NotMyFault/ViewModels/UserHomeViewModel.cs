using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System.Collections.Generic;

    namespace NotMyFault.ViewModels
{
    public class UserHomeViewModel
    {
        public ICollection<Project> MyInvolvedProjects { get; set; }
        public ICollection<Project> MyLeadingProjects { get; set; }
        public ICollection<Project> MyFollowingProjects { get; set; }
        public ICollection<Project> MyWatchingProjects { get; set; }
        public ICollection<Project> MyCompletedProjects { get; set; }
        public ICollection<Project> MyTradedProjects { get; set; }
        public ICollection<Project> MyAbortedProjects { get; set; }
        public Interview MyComingupIntws { get; set; }
        public ICollection<Endorsment> MyEndors{ get; set; }
        public ICollection<Recruitment> MyAppliedRoles{ get; set; }
        public bool IHaveReviews { get; set; }
        public int MyUserId { get; set; }
    }
}
