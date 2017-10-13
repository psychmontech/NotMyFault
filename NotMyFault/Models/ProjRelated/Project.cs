using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjName { get; set; }
        public string BriefDescript { get; set; }
        public string FullDescript { get; set; }
        public virtual ICollection<DeveloperProject> MyDevs { get; set; }
        public DateTime StartingDate { get; set; }
        public int Capacity { get; set; } //how many developers
        public Developer ProjLeader { get; set; }
        public Developer Initiator { get; set; }
        public byte MyGallery { get; set; } //for ad
        public DateTime NextMeetingDate { get; set; }
        public DateTime ProtdCompDate { get; set; } //projected complete date
        public byte Thumbnail { get; set; }  //profile photo
        public string RepoLink { get; set; } //github url
        public int Progress { get; set; } //percentage
        public long Valuation { get; set; } //how much you expect from the buyer
        public virtual ICollection<Recruitment> MyRecruits { get; set; } //its a list because you may have a few vacancies 
        public virtual ICollection<InternalConver> MyConver { get; set; } //within devs
        public virtual ICollection<PublicOpinion> MyPubOpin { get; set; }
        public virtual ICollection<Negotiation> MyNegos { get; set; } //between devs and buyers
        public virtual ICollection<Like> MyLikes { get; set; }
        public virtual ICollection<BuyerProject> MyWatchers { get; set; } //buys who are watching it
        public virtual ICollection<UserProject> MyFollowers { get; set; } //users who are interested in it
        public virtual Transaction MyTran { get; set; }
        public virtual Distribution MyDistribut { get; set; } //money division within devs
        public int Status { get; set; }
        public int Visibility { get; set; }
    }
}
