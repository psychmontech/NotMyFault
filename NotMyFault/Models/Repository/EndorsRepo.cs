using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.Repository.Interface;

namespace NotMyFault.Models.Repository
{
    public class EndorsRepo : IEndorsRepo
    {
        private readonly AppDbContext _appDbContext;

        public EndorsRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Endorsment> GetEndorsByUserId(int id) => _appDbContext.Endorsments.Include(c => c.MyDev.UserId == id).
            OrderByDescending(x => x.Timestamp).ToList();
    }
}
