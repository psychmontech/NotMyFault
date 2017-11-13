using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.UserRelated;

namespace NotMyFault.Models.Repository
{
    public class RecruitRepo : IRecruitRepo
    {
        private readonly AppDbContext _appDbContext;

        public RecruitRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Recruitment> GetAllRecruits() => _appDbContext.Recruitments.Include(r => r.MyProj).OrderBy(r => r.DateCreated).ToList();
        public ICollection<Recruitment> GetRecruitsByKeywords(string keywords) => _appDbContext.Recruitments.Include(r => r.MyProj).Where(r=> r.NameOfTheRole.Contains(keywords) || 
                                                                                  r.RoleDescription.Contains(keywords) || r.RequirDescript.Contains(keywords) || (keywords == null))
                                                                                  .OrderBy(r => r.DateCreated).ToList();
        public Recruitment GetRecruitById(int id) => _appDbContext.Recruitments.Include(r => r.MyProj).FirstOrDefault(r => r.RecruitmentId == id);
        public ICollection<Developer> GetCandiesByRecruId(int id) => _appDbContext.DevRecruits.Where(r => r.RecruitmentId == id).Select(d => d.Dev).ToList();
        public ICollection<Recruitment> GetRecruitsByCandyId(int id) => _appDbContext.DevRecruits.Where(c => c.Id == id).Select(r => r.Recruit).ToList();
        public ICollection<Interview> GetIntwByRecruId(int id) => _appDbContext.Interviews.Include(c => c.MyRecruit.RecruitmentId == id).OrderBy(x => x.Time).ToList();
        public bool ThisDevHasApplied(int id, Developer dev) => GetCandiesByRecruId(id).Contains(dev);
        public int SaveChanges() => _appDbContext.SaveChanges();
        public int AddRecruit(Recruitment recruit)
        {
            _appDbContext.Recruitments.Add(recruit);
            return _appDbContext.SaveChanges();
        }
        public int AddACandy(int id, Developer dev)
        {
            _appDbContext.DevRecruits.Add(
                new DeveloperRecruitment
                {
                    Recruit = GetRecruitById(id),
                    Dev = dev,
                });
            return _appDbContext.SaveChanges();
        }
    }
}
