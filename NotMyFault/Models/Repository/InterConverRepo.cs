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
    public class InterConverRepo : IInterConverRepo
    {
        private readonly AppDbContext _appDbContext;

        public InterConverRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<InterConverEntry> GetInterConverByProjId(int id) => _appDbContext.InterConverEntries.Include(p => p.MyProj).OrderBy(x => x.Timestamp).ToList().FindAll(c => c.MyProj.ProjectId == id);

        public int AddEntry(InterConverEntry entry)
        {
            _appDbContext.InterConverEntries.Add(entry);
            return _appDbContext.SaveChanges();
        }
    }
}
