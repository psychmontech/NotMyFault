using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.TransRelated
{
    public class Offer
    {
        public int OfferId { get; set; }
        public int BuyerId { get; set; } 
        public virtual Project MyProj { get; set; }
        public int Currency { get; set; }
        public double Value { get; set; }
    }
}
