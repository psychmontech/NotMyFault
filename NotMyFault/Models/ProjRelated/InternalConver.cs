using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;

namespace NotMyFault.Models.ProjRelated
{
    public class InternalConver
    {
        public Developer ByDev { get; set; }
        public DateTime Timestamp { get; set; }
        public string Text { get; set; }
        public virtual Project MyProj { get; set; }
    }
}
