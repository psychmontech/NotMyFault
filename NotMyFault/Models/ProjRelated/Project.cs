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
        public virtual List<DeveloperProject> MyDevs { get; set; }
        public DateTime StartingDate { get; set; }
        public int Capacity { get; set; } //how many developers
        public Developer ProjLeader { get; set; }
        public Developer Initiator { get; set; }
        public byte MyGallery { get; set; } //for ad
        public DateTime NextMeetingDate { get; set; }
        public DateTime ProtdCompDate { get; set; } //projected complete date
        public InternalConver MyConver { get; set; } //within devs
        public byte Thumbnail { get; set; }  //profile photo
        public string RepoLink { get; set; } //github url
        public decimal Progress { get; set; } //percentage
        public long Valuation { get; set; } //how much you expect from the buyer
        public virtual Recruitment MyRecruit { get; set; }
        public virtual List<PublicOpinion> MyPubOpin { get; set; }
        public virtual List<Negotiation> MyNegos { get; set; } //between devs and buyers
        public virtual List<Like> MyLikes { get; set; }
        public virtual List<BuyerProject> MyWatchers { get; set; } //buys who are watching it
        public virtual List<UserProject> MyFollowers { get; set; } //users who are interested in it
        public virtual Transaction MyTran { get; set; }
        public virtual Distribution MyDistribut { get; set; } //money division within devs

        public int Status { get; set; }
        public const int Status_Aborted = 0;
        public const int Status_Closed = 10;
        public const int Status_Preparing = 1;
        public const int Status_Recruiting = 2;
        public const int Status_Suspended = 6;
        public const int Status_Transaction_Processing = 5;
        public const int Status_Under_Development = 3;
        public const int Status_Under_Negotiation = 4;

        public int Visibility { get; set; }
        public const int Visi_Invisible = 0;
        public const int Visi_Only_Visible_To_Buyers = 1;
        public const int Visi_Visible_To_All_Users = 2;
        public const int Visi_Visible_To_Everyone = 3;
    }
}
