using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ViewDevProfileViewModel
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public byte Thumbnail { get; set; }
        public int NumProjWrkOn { get; set; }
        public string LinkedinUrl { get; set; }
        public int Credit { get; set; } //result of the reviews
        public ICollection<Endorsment> Endorsments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string SelfIntro { get; set; }
    }
}
