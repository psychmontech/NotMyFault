using NotMyFault.Models.ProjRelated.ConverEntries;
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
        public Project Myproj { get; set; }
        public IEnumerable<NegoEntry> MyEntries { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
