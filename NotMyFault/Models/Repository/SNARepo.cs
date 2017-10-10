using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class SNARepo : ISNARepo
    {
        private readonly AppDbContext _appDbContext;

        public SNARepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<SupptNAlleg> GetAllSNA() => _appDbContext.SupptNAllegs.Include(c => c.SupptNAllegId).ToList();
        public ICollection<SupptNAlleg> GetSNAByUserId(int id) => _appDbContext.SupptNAllegs.Include(c => c.MyUser.Id== id).
            OrderByDescending(x => x.SupptNAllegId).ToList();
        public ICollection<SNAEntry> GetSNAEntBySNAId(int id) => _appDbContext.SNAEntries.Include(c => c.MySNA.SupptNAllegId == id).
            OrderByDescending(x => x.Timestamp).ToList();

    }
}
