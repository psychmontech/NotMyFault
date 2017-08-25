using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Distribution
    {
        public string divisor { get; set; }
        public Project Myproj { get; set; }
        public IEnumerable<Developer> Associates { get; set; }
    }
}
