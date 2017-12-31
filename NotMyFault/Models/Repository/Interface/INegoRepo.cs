using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface INegoRepo
    {
        ICollection<Negotiation> GetNegoByProjId(int id);
        bool BuyerHasNegoWithProj(int buyerId, int projId);
        Negotiation GetNegoByBuyerProjId(int buyerId, int projId);
        ICollection<NegoEntry> GetNegoEntriesByBuyerProjId(int buyerId, int projId);
        int AddNego(Negotiation nego);
        int AddNegoEntry(NegoEntry entry);
    }
}
