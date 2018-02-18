using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class CryptcurValue
    {
        public int CryptcurValueId { get; set; }
        public double BitcoinValue { get; set; }
        public double EthereumValue { get; set; }
        public double LitecoinValue { get; set; }
        public bool AcceptBitcoid { get; set; }
        public bool AcceptEthereum { get; set; }
        public bool AcceptLitecoin { get; set; }
        public virtual Project MyProj { get; set; }
    }
}
