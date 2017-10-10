using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Negotiation
    {
        public int NegotiationId { get; set; }
        public virtual Buyer MyBuyer { get; set; } //always talk to the leader of the proj
        public virtual Project MyProj { get; set; }
        public virtual ICollection<NegoEntry> MyEntries { get; set; }
    }

    public class NegoEntry
    {
        public DateTime Timestamp { get; set; }
        public virtual Negotiation MyNego { get; set; }
        public string Text { get; set; }
    }
}
