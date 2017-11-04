using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IRecruitRepo
    {
        ICollection<Recruitment> GetAllRecruits();
        Recruitment GetRecruitsByRecruitId(int id);
        ICollection<Recruitment> GetRecruitsByProjId(int id);
        Boolean GetRecruOpenStatByRecruId(int id);
        ICollection<Interview> GetIntwByRecruId(int id);
        int AddRecruit(Recruitment recruit);
    }
}
