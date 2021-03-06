﻿using NotMyFault.Models.TransRelated;
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
        public string MissionStatement { get; set; }
        public string FullDescript { get; set; }
        public virtual ICollection<DeveloperProject> MyDevs { get; set; }
        public Nullable<DateTime> StartingDate { get; set; }
        public Developer ProjLeader { get; set; }
        public Developer Initiator { get; set; }
        public byte MyGallery { get; set; } //for ad
        public Nullable<DateTime> NextMeetingDate { get; set; }
        public Nullable<DateTime> ProtdCompDate { get; set; } //projected complete date
        public byte Thumbnail { get; set; }  //profile photo
        public string RepoLink { get; set; } //github url
        public int Progress { get; set; } //percentage
        public virtual CryptcurValue Valuation { get; set; } //how much you expect from the buyer
        public virtual ICollection<Recruitment> MyRecruits { get; set; } //its a list because you may have a few vacancies 
        public virtual ICollection<InterConverEntry> MyConver { get; set; } //within devs
        public virtual ICollection<PublicOpinion> MyPubOpin { get; set; }
        public virtual ICollection<Negotiation> MyNegos { get; set; } //between devs and buyers
        public virtual ICollection<Like> MyLikes { get; set; }
        public virtual ICollection<Offer> MyOffers { get; set; }
        public virtual ICollection<BuyerProject> MyWatchers { get; set; } //buys who are watching it
        public virtual ICollection<UserProject> MyFollowers { get; set; } //users who are interested in it
        public virtual Transaction MyTran { get; set; }
        public virtual Distribution MyDistribut { get; set; } //money division within devs
        public int ProjStatus { get; set; }
        public int TradingStatus { get; set; }
        public int Visibility { get; set; }
        public Nullable<DateTime> CompleteDate { get; set; }
        public Nullable<DateTime> AbortDate { get; set; }
    }
}
