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
    public class NegoRepo : INegoRepo
    {
        private readonly AppDbContext _appDbContext;

        public NegoRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Negotiation> GetNegoByProjId(int id) => _appDbContext.Negotiations.Include(c => c.MyProj.ProjectId == id).
            OrderByDescending(x => x.NegotiationId).ToList();
        public List<NegoEntry> GetNegoEntByNegoId(int id) => _appDbContext.NegoEntries.Include(c => c.MyNego.NegotiationId == id).
            OrderByDescending(x => x.Timestamp).ToList();

    }
}
