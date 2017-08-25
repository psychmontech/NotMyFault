using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated.ConverEntries
{
    public class PublicEntry
    {
        public DateTime Timestamp { get; set; }
        public PublicOpinion MyPublicOp { get; set; }
        public Visitor MyVisitor { get; set; }
        public string Text { get; set; }
    }
}
