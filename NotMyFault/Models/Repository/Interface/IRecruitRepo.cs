using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IRecruitRepo
    {
        List<Recruitment> GetRecruitsByProjId(int id);
        Boolean GetRecruOpenStatByRecruId(int id);
        CandiRqrmt GetCandiRqrmtByRecruId(int id);
        Interview GetIntwByRecruId(int id);
    }
}
