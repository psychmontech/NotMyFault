using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IReviewRepo
    {
        ICollection<Review> GetRevByUserId(int id);
        ICollection<ProjWithIfDevIsRated> GetProjsWithIfDevIsRated(int reviewerId, int revieweeId);
        int AddReview(Review review);
    }
}
