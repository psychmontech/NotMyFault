using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ViewUserProfileViewModel
    {
        public Developer CurrentDev { get; set; }
        public Developer ViewingDev { get; set; }
        public Buyer CurrentBuyer { get; set; }
        public int NumProjWrkOn { get; set; }
        public string LinkedinUrl { get; set; }
        public int Credit { get; set; } //result of the reviews
        public ICollection<Endorsment> Endorsments { get; set; }
        public ICollection<ProjWithIfDevIsRated> ProjsWithIfDevIsRated { get; set; }
    }
}
