using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Negotiation
    {
        public Buyer MyBuyer { get; set; }
        public virtual Project MyProj { get; set; }
        public virtual List<NegoEntry> MyEntries { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class NegoEntry
    {
        public Developer Developer { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual Negotiation MyNego { get; set; }
        public Buyer Buyer { get; set; }
        public string Text { get; set; }
    }
}
