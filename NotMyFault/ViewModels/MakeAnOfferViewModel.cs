using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class MakeAnOfferViewModel  //this is shared by makeAnOffer and SeeOffers
    {
        public int ProjId { get; set; }
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; } //this is used by 'seeOffers' not by 'makeAnOffer'
        public int Currency { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid cryptocurrency value")]
        public double Value { get; set; }
        public List<int> AcceptCurrency { get; set; }
    }
}
