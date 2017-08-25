using NotMyFault.Models.ProjRelated.ConverEntries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class InternalConver
    {
        public IEnumerable<InterConvEntry> MyEntries { get; set; }
        public Project MyProj { get; set; }
    }
}
