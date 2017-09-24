using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IRecruitRepo
    {
        Recruitment GetRecruitByProjId(int id);
        Boolean GetRecruitOpenStatusByProjId(int id);
        CandiRqrmt GetCandiRqrmtByRecruitId(int id);
        Interview GetIntwByRecruitId(int id);
    }
}
