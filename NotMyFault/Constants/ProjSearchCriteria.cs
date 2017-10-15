using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Constants
{
    public static class ProjSearchCriteria
    {
        public const int ByOpenDate = 1;
        public const int ByValuation = 2;
        public const int ByPopularity = 3;
        public const int ByProgress = 4;

        public const int OpenOnly = 1;
        public const int CompletedOnly = 2;
        public const int OpenInclSusp = 3;
        public const int All = 4;
        public const int AllInclSusp = 5;
    }
}
