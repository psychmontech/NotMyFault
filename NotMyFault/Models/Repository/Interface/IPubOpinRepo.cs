using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IPubOpinRepo
    {
        List<PublicOpinion> GetPubOpinByProjId(int id);
    }
}
