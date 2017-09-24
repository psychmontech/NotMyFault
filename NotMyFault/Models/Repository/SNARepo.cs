using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Misce;
using NotMyFault.Models.Repository.Interface;
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

        public List<SupptNAlleg> GetAllSNA() => _appDbContext.SupptNAllegs.Include(c => c.SupptNAllegId).ToList();
        public List<SupptNAlleg> GetSNAByUserId(int id) => _appDbContext.SupptNAllegs.Include(c => c.MyUser.Userid== id).
            OrderByDescending(x => x.SupptNAllegId).ToList();
        public List<SNAEntry> GetSNAEntBySNAId(int id) => _appDbContext.SNAEntries.Include(c => c.MySNA.SupptNAllegId == id).
            OrderByDescending(x => x.Timestamp).ToList();

    }
}
