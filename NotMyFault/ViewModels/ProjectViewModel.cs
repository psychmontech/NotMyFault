using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ProjectViewModel
    {
        public Project Proj { get; set; }
        public int Capacity { get; set; }
        public int NumOfLikes { get; set; }
        public int NumOfFollowers { get; set; }
        public int NumOfWatchers { get; set; }
        public User CurrentUser { get; set; }
        public Developer ProjLeader { get; set; }
        public ICollection<Developer> MyDevs { get; set; }
        public CryptcurValue Valuation { get; set; }
        public string PreviousInterConver { get; set; }
        public string PreviousNegoConver { get; set; }
        public bool CurrentDevIsInvolved { get; set; }
        public bool CurrentUserHasLiked { get; set; }
        public bool CurrentUserHasFollowed { get; set; }
        public bool CurrentBuyerHasWatched { get; set; }
        public bool HasOpenRecruits { get; set; }
        public bool HasOffers { get; set; }
        public bool HasAnyNegosToLookat { get; set; }
    }
}
