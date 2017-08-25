using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.TransRelated
{
    public class tradeBox
    {
        public Transaction Mytran { get; set; }
        public Boolean IsGdInPlc { get; set; }
        public Boolean IsGdVerified { get; set; }
        public Boolean IsMoneyInPlc { get; set; }
        public Boolean IsMoneyVerified { get; set; }
        public Boolean IsEmpty { get; set; }
        public Boolean IsReadyForEx { get; set; }
        public DateTime GdInPlcTs { get; set; }
        public DateTime GdVerifiedTs { get; set; }
        public DateTime MoneyInPlcTs { get; set; }
        public DateTime MoneyVerifiedTs { get; set; }
        public Byte Goods { get; set; }
    }
}
