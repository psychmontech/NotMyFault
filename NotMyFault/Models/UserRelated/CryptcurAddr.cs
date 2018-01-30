using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class CryptcurAddr
    {
        public int CryptcurAddrId { get; set; }
        public string BitcoinAddr { get; set; }
        public string EthereumAddr { get; set; }
        public string LitecoinAddr { get; set; }
        public virtual User MyUser { get; set; }
    }
}
