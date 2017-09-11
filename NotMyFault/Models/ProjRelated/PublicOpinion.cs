using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class PublicOpinion
    {
        public DateTime Timestamp { get; set; }
        public Visitor MyVisitor { get; set; }
        public string Text { get; set; }
        public virtual Project MyProj { get; set; }
    }
}
