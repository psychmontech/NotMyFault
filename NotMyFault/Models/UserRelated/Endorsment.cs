using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Endorsment
    {
        public int EndorsmentId { get; set; }
        public virtual Developer MyDev { get; set; }
        public virtual Developer FromDev { get; set; }
        public string subject { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
    