using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;
using NotMyFault.Models.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Constants;
using NotMyFault.ViewModels;
using Microsoft.Extensions.Logging;

namespace NotMyFault.Models.Repository
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;

        public ReviewRepo(AppDbContext appDbContext, ILogger<ReviewRepo> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public ICollection<Review> GetRevByUserId(int id) => _appDbContext.Reviews.Include(r=>r.Reviewee).Where(c => c.Reviewee.Id == id).OrderByDescending(x => x.Timestamp).ToList();
        public ICollection<ProjWithIfDevIsRated> GetProjsWithIfDevIsRated(int reviewerId, int revieweeId)
        {
            ICollection<Project> projsThatHasThisReviewer = _appDbContext.DevProjs.Where(d => d.Dev.Id == reviewerId).Select(p => p.Proj).Where(p => p.Status == ProjStatus.Aborted || p.Status == ProjStatus.Completed).ToList();
            ICollection<ProjWithIfDevIsRated> result = new List<ProjWithIfDevIsRated>();
            Developer reviewee = _appDbContext.Devs.FirstOrDefault(p => p.Id == revieweeId);
            foreach (var proj in projsThatHasThisReviewer)
            {
                if (_appDbContext.DevProjs.Where(p => p.ProjectId == proj.ProjectId).Select(d => d.Dev).ToList().Contains(reviewee))
                {
                    _logger.LogCritical(1002, "$$$$$$$$$$$ proj.ProjectId {ID}", proj.ProjectId);
                    _logger.LogCritical(1002, "$$$$$$$$$$$ revieweeId {ID}", revieweeId);
                    result.Add(new ProjWithIfDevIsRated
                    {
                        Proj = proj,
                        CurrentDevHasRatedThisDev = _appDbContext.Reviews.Include(r => r.Reviewee).
                                                    Where(r => r.ProjId == proj.ProjectId && r.ReviewerId == reviewerId && r.Reviewee.Id == revieweeId).Any()
                    });
                }
            }
            return result;
        }

        public int AddReview(Review review)
        {
            _appDbContext.Reviews.Add(review);
            return _appDbContext.SaveChanges();
        }
    }
}
