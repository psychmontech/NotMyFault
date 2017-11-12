using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ReviewViewModel
    {
        public int RevieweeId { get; set; }
        public string RevieweeName { get; set; }
        public int ReviewerId { get; set; }
        public int ProjId { get; set; }
        public string ProjName { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
