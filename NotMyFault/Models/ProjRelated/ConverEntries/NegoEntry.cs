using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated.ConverEntries
{
    public class NegoEntry
    {
        public Developer Developer { get; set; }
        public DateTime Timestamp { get; set; }
        public Negotiation MyNego { get; set; }
        public Buyer Buyer { get; set; }
        public string Text { get; set; }
    }
}
