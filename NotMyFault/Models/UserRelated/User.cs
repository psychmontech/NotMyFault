using NotMyFault.Models.Misce;
using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public abstract class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public byte Thumbnail { get; set; }
        public virtual List<SupptNAlleg> MySupNAlleg { get; set; }
        public virtual List<UserProject> MyFollowings { get; set; }
    }

    public class Developer : User
    {
        public int Age { get; set; }
        public string EmailAddr { get; set; }
        public string LinkedinUrl { get; set; }
        public int Credit { get; set; } //result of the reviews
        public virtual List<Endorsment> MyEndors { get; set; } //like linkedin
        public virtual List<Endorsment> EndorsIGive { get; set; } 
        public virtual List<DeveloperProject> MyProjs { get; set; }
        public virtual List<Project> MyLeadingProjs { get; set; }
        public virtual List<Project> MyInitiatedProjs { get; set; }
        public virtual List<DeveloperRecruitment> MyAppliedRoles { get; set; }
        public virtual string MySkills { get; set; } //self claim
        public virtual BankDetails MyBankDetails { get; set; }
        public virtual List<Review> MyReviews { get; set; } //reviews by other devs, conducts review -/+ 5 
        public virtual List<Review> MyReviewed { get; set; } //all that reviewed by me 
    }

    public class Buyer : User
    {
        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
        public virtual List<BuyerProject> MyWatchingProj { get; set; }
        public long Earnest { get; set; }
        public virtual List<Negotiation> MyNegos { get; set; }
    }

    //many to many join tables
    public class DeveloperProject
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public Developer Dev { get; set; }
        public Project Proj { get; set; }
    }

    public class DeveloperRecruitment
    {
        public int RecruitmentId { get; set; }
        public int UserId { get; set; }
        public Developer Dev { get; set; }
        public Recruitment Recruit { get; set; }
    }
    public class UserProject
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Project Proj { get; set; }
    }
    public class BuyerProject
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public Buyer Buyer { get; set; }
        public Project Proj { get; set; }
    }

}
