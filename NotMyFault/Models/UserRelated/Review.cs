using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Review
    {
        public string Comments { get; set; }
        public DateTime Timestamp { get; set; }
        public int Score { get; set; }
        public virtual Developer Reviewee { get; set; }
        public int ReviewerId { get; set; }
        public int ProjId { get; set; }
    }
}
