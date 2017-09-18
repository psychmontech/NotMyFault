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
        public DateTime DateAborted { get; set; }
        public DateTime DateCompleted { get; set; }
        public Boolean IsAborted { get; set; }
        public Boolean IsCompleted { get; set; }
        public Buyer MyBuyer { get; set; }
        public List<Developer> MyDevs { get; set; }
        public long TranAmount { get; set; }
        public int Currency { get; set; }
        public int TranId { get; set; }
        public virtual TradeBox MyTradeBox { get; set; }
        public virtual Project MyProj { get; set; }

        public const int USD = 1;
        public const int CNY = 2;
        public const int EUR = 3;
        public const int NZD = 4;

    }
}
