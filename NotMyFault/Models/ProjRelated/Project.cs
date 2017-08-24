using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Project
    {
        public string ProjName { get; set; }
        public string BriefDescription { get; set; }
        public string FullDescription { get; set; }
        public DateTime StartingDate { get; set; }
        public int Capacity { get; set; }
    }
}
