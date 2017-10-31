using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace NotMyFault.Models.Repository
{
    public class RecruitRepo : IRecruitRepo
    {
        private readonly AppDbContext _appDbContext;

        public RecruitRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Recruitment> GetRecruitsByProjId(int id) => _appDbContext.Recruitments.Include(c => c.MyProj.ProjectId == id).OrderBy(x => x.RecruitmentId).ToList();
        public bool GetRecruOpenStatByRecruId(int id) => _appDbContext.Recruitments.FirstOrDefault(c => c.MyProj.ProjectId == id).IsOpen;
        public ICollection<Interview> GetIntwByRecruId(int id) => _appDbContext.Interviews.Include(c => c.MyRecruit.RecruitmentId == id).OrderBy(x => x.Time).ToList();

    }
}
