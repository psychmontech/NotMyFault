using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
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
        public ICollection<Negotiation> GetNegoByProjId(int id) => _appDbContext.Negotiations.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);
        public bool BuyerHasNegoWithProj(int buyerId, int projId) => GetNegoByProjId(projId).Where(n => n.BuyerId == buyerId).Any();
        public Negotiation GetNegoByBuyerProjId(int buyerId, int projId) => GetNegoByProjId(projId).FirstOrDefault(n => n.BuyerId == buyerId);
        public ICollection<NegoEntry> GetNegoEntriesByBuyerProjId(int buyerId, int projId) => _appDbContext.NegoEntries.Include(n => n.MyNego).
                                      OrderBy(n => n.Timestamp).ToList().FindAll(n => n.MyNego == GetNegoByBuyerProjId(buyerId, projId));
        public int AddNego(Negotiation nego)
        {
            _appDbContext.Negotiations.Add(nego);
            return _appDbContext.SaveChanges();
        }
        public int AddNegoEntry(NegoEntry entry)
        {
            _appDbContext.NegoEntries.Add(entry);
            return _appDbContext.SaveChanges();
        }

    }
}
