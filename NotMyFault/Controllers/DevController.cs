using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class DevController : Controller
    {
        public IDevRepo _DevRepo { get; set; }
        public IReviewRepo _ReviewRepo { get; set; }
        public IProjRepo _ProjRepo { get; set; }
        public IRecruitRepo _RecruitRepo { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public DevController(IDevRepo devRepo, UserManager<User> userManager, ILogger<ProjectController> logger,
                             IReviewRepo reviewRepo, IProjRepo projRepo, IRecruitRepo recruitRepo)
        {
            _DevRepo = devRepo;
            _ReviewRepo = reviewRepo;
            _ProjRepo = projRepo;
            _RecruitRepo = recruitRepo;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHomeViewModel = new UserHomeViewModel
            {
                MyLeadingProjects = _DevRepo.GetMyLeadingProjsById(user.Id),
                MyInvolvedProjects = _DevRepo.GetMyProjsById(user.Id),
                MyFollowingProjects = _DevRepo.GetMyFollowingsById(user.Id),
                MyCompletedProjects = _DevRepo.GetMyCompletedProjsById(user.Id),
                MyTradedProjects = _DevRepo.GetMyTradedProjsById(user.Id),
                MyAbortedProjects = _DevRepo.GetMyAbortedProjsById(user.Id),
                MyEndors = _DevRepo.GetEndorsById(user.Id),
                MyAppliedRoles = _RecruitRepo.GetRecruitsByCandyId(user.Id),
                IHaveReviews = _ReviewRepo.ThisUserHasReviews(user.Id),
                MyUserId = user.Id
            };
            return View(userHomeViewModel);  
        }

        public async Task<IActionResult> ViewDevProfile(int id)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            var currentUser = (Developer)await _userManager.GetUserAsync(User);
            Developer dev = _DevRepo.GetDevById(id);
            ViewUserProfileViewModel viewUserProfileViewModel = new ViewUserProfileViewModel
            {
                CurrentDev = currentUser,
                ViewingDev = dev,
                NumProjWrkOn = _DevRepo.GetNumProjWrkOnById(id),
                Credit = _DevRepo.GetCreditById(id),
                ProjsWithIfDevIsRated = _ReviewRepo.GetProjsWithIfDevIsRated(currentUser.Id, dev.Id)
            };
            return View(viewUserProfileViewModel);
        }

        public ViewResult Rate(int revieweeId, int projId)
        {
            ReviewViewModel reviewViewModel = new ReviewViewModel
            {
                RevieweeId = revieweeId,
                RevieweeNickName = _DevRepo.GetDevById(revieweeId).NickName,
                ProjId = projId,
                ProjName = _ProjRepo.GetProjById(projId).ProjName
            };
            return View(reviewViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Rate(ReviewViewModel reviewViewModel)
        {
            var currentUser = (Developer)await _userManager.GetUserAsync(User);
            Review review = new Review
            {
                Score = reviewViewModel.Score,
                Comments = reviewViewModel.Comments,
                ReviewerId = currentUser.Id,
                Reviewee = _DevRepo.GetDevById(reviewViewModel.RevieweeId),
                Timestamp = DateTime.Now,
                ProjId = reviewViewModel.ProjId
            };
            _ReviewRepo.AddReview(review);
            return RedirectToAction("ViewDevProfile", "Dev", new { id = reviewViewModel.RevieweeId });
        }

        public ViewResult ViewReviews(int id)
        {
            var reviews = _ReviewRepo.GetRevByUserId(id);
            var reviewViews = new List<ReviewViewModel>(); 
            foreach (var review in reviews)
            {
                reviewViews.Add(new ReviewViewModel
                {
                    Score = review.Score,
                    Comments = review.Comments,
                    Timestamp = review.Timestamp,
                    ProjId = review.ProjId,
                    ProjName = _ProjRepo.GetProjnameById(review.ProjId),
                    RevieweeId = review.Reviewee.Id,
                    RevieweeNickName = _DevRepo.GetNickNameById(review.Reviewee.Id),
                    ReviewerId = review.ReviewerId,
                    ReviewerNickName = _DevRepo.GetNickNameById(review.ReviewerId)
                });
                    
            }
            return View(reviewViews);
        }
    }
}
