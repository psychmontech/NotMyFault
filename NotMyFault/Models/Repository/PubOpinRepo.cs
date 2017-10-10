using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class PubOpinRepo
    {
        private readonly AppDbContext _appDbContext;

        public PubOpinRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<PublicOpinion> GetPubOpinByProjId (int id) => _appDbContext.PublicOpinions.Include(c => c.MyProj.ProjectId == id).
            OrderByDescending(x => x.Timestamp).ToList();
        
    }
}
