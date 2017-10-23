using Microsoft.AspNetCore.Identity;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using System;
using System.Collections.Generic;

namespace NotMyFault.Models.UserRelated
{
    public class User : IdentityUser<int>
    {
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }  
        public int Role { get; set; }
        public byte Thumbnail { get; set; }
        public virtual ICollection<SupptNAlleg> MySupNAlleg { get; set; }
        public virtual ICollection<UserProject> MyFollowings { get; set; }
        public virtual ICollection<Like> ProjILiked { get; set; }
    }

    public class Developer : User 
    {
        public string LinkedinUrl { get; set; }
        public string SelfIntro { get; set; } //self claim
        public virtual ICollection<Endorsment> MyEndors { get; set; } //like linkedin
        public virtual ICollection<Endorsment> EndorsIGive { get; set; } 
        public virtual ICollection<DeveloperProject> MyProjs { get; set; }
        public virtual ICollection<Project> MyLeadingProjs { get; set; }
        public virtual ICollection<Project> MyInitiatedProjs { get; set; }
        public virtual ICollection<DeveloperRecruitment> MyAppliedRoles { get; set; }
        public virtual BankDetails MyBankDetails { get; set; }
        public virtual Interview MyIntwAsViewer { get; set; }
        public virtual Interview MyIntwAsViewee { get; set; }
        public virtual ICollection<Review> MyReviews { get; set; } //reviews by other devs, conducts review -/+ 5 
        public virtual ICollection<Review> MyReviewed { get; set; } //all that reviewed by me 
        public virtual ICollection<InternalConver> MyInterconvers { get; set; } 
    }

    public class Buyer : User
    {
        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
        public virtual ICollection<BuyerProject> MyWatchingProj { get; set; }
        public int Earnest { get; set; }
        public virtual ICollection<Negotiation> MyNegos { get; set; }
        public virtual ICollection<Transaction> AssociateTrans { get; set; }
    }

    //many to many join tables
    public class DeveloperProject
    {
        public int ProjectId { get; set; }
        public int Id { get; set; }
        public Developer Dev { get; set; }
        public Project Proj { get; set; }
    }

    public class DeveloperRecruitment
    {
        public int RecruitmentId { get; set; }
        public int Id { get; set; }
        public Developer Dev { get; set; }
        public Recruitment Recruit { get; set; }
    }
    public class UserProject
    {
        public int ProjectId { get; set; }
        public int Id { get; set; }
        public User User { get; set; }
        public Project Proj { get; set; }
    }
    public class BuyerProject
    {
        public int ProjectId { get; set; }
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public Project Proj { get; set; }
    }

}
