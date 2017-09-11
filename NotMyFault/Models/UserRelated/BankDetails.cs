using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class BankDetails
    {
        public int BankDetailsId { get; set; }
        public string AcctName { get; set; }
        public string AcctNo { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public int DeveloperForeignKey { get; set; }
        public virtual Developer MyDev { get; set; }
    }
}
