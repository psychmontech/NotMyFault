using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Misce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class DevRepo : IDevRepo
    {
        private readonly AppDbContext _appDbContext;

        public DevRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Developer> Devs
        {
            get
            {
                return _appDbContext.Devs.Include(c => c.UserId).ToList();
            } 
        }

        public Developer GetDevById(int id)
        {
            return _appDbContext.Devs.FirstOrDefault(p => p.UserId == id);
        }

    }
}
