using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.TransRelated
{
    public class TradeBox
    {
        public int TradeBoxId { get; set; }
        public virtual Transaction Mytran { get; set; }
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
        public byte Goods { get; set; }
        public Project MyProj { get; set; }

    }
}
