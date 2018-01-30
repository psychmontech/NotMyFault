using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.TransRelated
{
    public class Transaction
    {
        public int TranId { get; set; }
        public DateTime DateAborted { get; set; }
        public DateTime DateCompleted { get; set; }
        public Boolean IsAborted { get; set; }
        public Boolean IsCompleted { get; set; }
        public virtual Buyer MyBuyer { get; set; }
        public Decimal TranAmount { get; set; }
        public virtual TradeBox MyTradeBox { get; set; }
        public virtual Project MyProj { get; set; }
    }
}
