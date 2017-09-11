using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Distribution
    {
        public int DistributionId { get; set; }
        public string divisor { get; set; }
        public virtual Project MyProj { get; set; }
        public int ProjectForeignKey { get; set; }
        public List<Developer> Associates { get; set; } 
    }
}
