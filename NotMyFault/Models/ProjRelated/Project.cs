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
        public int Status { get; set; }
        public const int Status_Aborted = 0;
        public const int Status_Closed = 10;
        public const int Status_Preparing = 1;
        public const int Status_Recruiting = 2;
        public const int Status_Suspended = 7;
        public const int Status_Transaction_Processing = 5;
        public const int Status_Under_Development = 3;
        public const int Status_Under_Negotiation = 4;
        public int Visibility { get; set; }
        public const int Invisible = 0;
        public const int Only_Visible_To_Buyers = 1;
        public const int Visible_To_All_Users = 2;
        public const int Visible_To_Everyone = 3;
    }
}
