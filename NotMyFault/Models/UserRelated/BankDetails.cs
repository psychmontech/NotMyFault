using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class BankDetails
    {
        public string AcctName { get; set; }
        public string AcctNo { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public Developer MyDeveloper { get; set; }
    }
}
