using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;

namespace NotMyFault.Models.ProjRelated.ConverEntries
{
    public class InterConvEntry
    {
        public Developer ByDev { get; set; }
        public DateTime Timestamp { get; set; }
        public InternalConver MyConver { get; set; }
        public string Text { get; set; }
    }
}
