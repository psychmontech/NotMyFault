using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class CrypCurAddr
    {
        public int CrypCurAddrId { get; set; }
        public string BitCoinAddr { get; set; }
        public string EthereumAddr { get; set; }
        public string LitecoinAddr { get; set; }
        public virtual Developer MyDev { get; set; }
    }
}
