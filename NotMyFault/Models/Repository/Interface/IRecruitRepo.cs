using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IRecruitRepo
    {
        ICollection<Recruitment> GetAllRecruits();
        ICollection<Recruitment> GetRecruitsByKeywords(string keywords);
        ICollection<Recruitment> GetRecruitsByCandyId(int id);
        Recruitment GetRecruitById(int id);
        ICollection<Interview> GetIntwByRecruId(int id);
        ICollection<Developer> GetCandiesByRecruId(int id);
        bool ThisDevHasApplied(int id, Developer dev);
        int AddRecruit(Recruitment recruit);
        int AddACandy(int id, Developer dev);
        int SaveChanges();
    }
}
