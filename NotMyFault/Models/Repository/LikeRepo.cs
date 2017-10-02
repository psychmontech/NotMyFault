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
    public class LikeRepo : ILikeRepo
    {
        private readonly AppDbContext _appDbContext;

        public LikeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Like> GetLikesByProjId (int id) => _appDbContext.Likes.Include(c => c.MyProj.ProjectId == id).
            OrderByDescending(x=>x.Timestamp).ToList();
    }
}
