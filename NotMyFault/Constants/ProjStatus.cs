using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Constants
{
    public static class ProjStatus
    {
        public const int Aborted = 0;
        public const int Closed = 10;
        public const int Preparing = 1;
        public const int Recruiting = 2;
        public const int Suspended = 6;
        public const int Transaction_Processing = 5;
        public const int Under_Development = 3;
        public const int Under_Negotiation = 4;
    }
}
