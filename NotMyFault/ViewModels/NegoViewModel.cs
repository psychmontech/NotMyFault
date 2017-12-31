using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class NegoViewModel
    {
        //this viewmode is shared between TalkToBuyers and NegoWithBuyer
        public ICollection<Buyer> Buyers { get; set; }
        public int ProjId { get; set; }
        public int BuyerId { get; set; }
        public User CurrentUser { get; set; }
        public string PreviousNegoConver { get; set; }
    }
}
