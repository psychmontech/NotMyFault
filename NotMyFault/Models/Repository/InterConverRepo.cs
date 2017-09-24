using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Misce;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class InterConverRepo : IInterConverRepo
    {
        private readonly AppDbContext _appDbContext;

        public InterConverRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<InternalConver> GetInterConverByProjId (int id) => _appDbContext.InternalConver.Include(c => c.MyProj.ProjectId == id).
            OrderByDescending(x => x.Timestamp).ToList();
    }
}
