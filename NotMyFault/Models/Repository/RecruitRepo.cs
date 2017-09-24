using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Misce;

namespace NotMyFault.Models.Repository
{
    public class RecruitRepo : IRecruitRepo
    {
        private readonly AppDbContext _appDbContext;

        public RecruitRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Recruitment GetRecruitByProjId(int id) => _appDbContext.Recruitments.FirstOrDefault(c => c.MyProj.ProjectId == id);
        public CandiRqrmt GetCandiRqrmtByRecruitId(int id) => _appDbContext.CandiRqrmts.FirstOrDefault(c => c.MyRecruit.RecruitmentId == id);

        public Interview GetIntwByRecruitId(int id) => _appDbContext.Interviews.FirstOrDefault(c => c.MyRecruit.RecruitmentId == id);

        public bool GetRecruitOpenStatusByProjId(int id) => _appDbContext.Recruitments.FirstOrDefault(c => c.MyProj.ProjectId == id).IsOpen;

    }
}
