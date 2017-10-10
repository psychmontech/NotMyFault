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
        ICollection<NegoEntry> GetNegoEntByNegoId(int id);
    }
}
