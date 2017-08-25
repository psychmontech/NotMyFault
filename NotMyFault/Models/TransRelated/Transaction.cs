﻿using NotMyFault.Models.ProjRelated;
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
        public IEnumerable<Developer> MyDevelopers { get; set; }
        public Project MyProject { get; set; }
        public long TranAmount { get; set; }
        public long TranId { get; set; }
        public tradeBox MyTradeBox { get; set; }
    }
}
