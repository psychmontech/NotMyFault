using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;
using NotMyFault.Models.Misce;
using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Repository.Interface;

namespace NotMyFault.Models.Repository
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly AppDbContext _appDbContext;

        public ReviewRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Review> GetRevByUserId(int id) => _appDbContext.Reviews.Include(c => c.MyReviewee.UserId == id).OrderByDescending(x => x.Timestamp).ToList();
    }
}
