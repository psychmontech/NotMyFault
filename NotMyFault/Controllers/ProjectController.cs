using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Constants;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static NotMyFault.Models.ProjRelated.Project;

namespace NotMyFault.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<User> _userManager;
        public IProjRepo _projRepo { get; set; }
        public ILikeRepo _likeRepo { get; set; }
        public INegoRepo _negoRepo { get; set; }
        private readonly ILogger _logger;
        public ProjectController(UserManager<User> userManager, IProjRepo ProjRepo, ILogger<ProjectController> logger,
                                ILikeRepo LikeRepo, INegoRepo negoRepo)
        {
            _userManager = userManager;
            _projRepo = ProjRepo;
            _likeRepo = LikeRepo;
            _negoRepo = negoRepo;
            _logger = logger;
        }
        public async Task<ViewResult> Index(int id)
        {
            var proj = _projRepo.GetProjById(id);
            var thisUser = await _userManager.GetUserAsync(User);
            ProjectViewModel projectViewModel = new ProjectViewModel
            {
                Proj = proj,
                Capacity = _projRepo.GetCapacityById(id),
                ProjLeader = _projRepo.GetProjLeaderById(id),
                Valuation = _projRepo.GetValuationById(id),
                MyDevs = _projRepo.GetMyDevsById(id),
                NumOfFollowers = _projRepo.GetMyFollowersById(id).Count,
                NumOfLikes = _projRepo.GetMyLikesById(id).Count,
                NumOfWatchers = _projRepo.GetMyWatchersById(id).Count,
                HasOpenRecruits = _projRepo.HasOpenRecruits(id)
            };

            if (thisUser.Role == UserRole.Dev)
            {
                var interConver = _projRepo.GetMyConverById(id);
                string previousInterConver = null;
                foreach (var entry in interConver)
                {
                    previousInterConver += entry.DevNickName + ": " + entry.Text + "\n";
                }
                projectViewModel.CurrentUser = (Developer)thisUser;
                projectViewModel.PreviousInterConver = previousInterConver;
                projectViewModel.CurrentDevIsInvolved = _projRepo.ThisDevIsInvolved(thisUser, id);
                projectViewModel.CurrentUserHasLiked = _projRepo.ThisUserHasLiked(thisUser, id);
                projectViewModel.CurrentUserHasFollowed = _projRepo.ThisUserHasFollowed(thisUser, id);
                projectViewModel.CurrentBuyerHasWatched = false;
                projectViewModel.HasAnyNegosToLookat = _projRepo.HasAnyNegosToLookat(id);
            }
            else
            {
                var NegoEntries = _negoRepo.GetNegoEntriesByBuyerProjId(thisUser.Id, id);
                string previousNegoConver = null;
                foreach (var entry in NegoEntries)
                {
                    previousNegoConver += entry.UserNickName + ": " + entry.Text + "\n";
                }
                projectViewModel.PreviousNegoConver = previousNegoConver;
                projectViewModel.CurrentUser = (Buyer)thisUser;
                projectViewModel.CurrentDevIsInvolved = false;
                projectViewModel.CurrentUserHasLiked = _projRepo.ThisUserHasLiked(thisUser, id);
                projectViewModel.CurrentUserHasFollowed = _projRepo.ThisUserHasFollowed(thisUser, id);
                projectViewModel.CurrentBuyerHasWatched = _projRepo.ThisBuyerHasWatched(thisUser, id);
            }

            return View(projectViewModel);
        }

        public ViewResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectViewModel createProjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Developer thisDev = (Developer)await _userManager.GetUserAsync(User);
                ICollection<DeveloperProject> devproj = new List<DeveloperProject> { new DeveloperProject { Dev = thisDev } };
                Project proj = new Project
                {
                    ProjName = createProjectViewModel.ProjName,
                    BriefDescript = createProjectViewModel.BriefDescript,
                    FullDescript = createProjectViewModel.FullDescript,
                    Valuation = new CryptcurValue
                    {
                        BitcoinValue = createProjectViewModel.Value_bitcoin,
                        EthereumValue = createProjectViewModel.Value_ethereum,
                        LitecoinValue = createProjectViewModel.Value_litecoin
                    },
                    Visibility = createProjectViewModel.Visibility,
                    ProjLeader = thisDev,
                    Initiator = thisDev,
                    MyDevs = devproj,
                    Status = ProjStatus.Preparing,
                    ProtdCompDate = createProjectViewModel.ProtdCompDate,
                    StartingDate = DateTime.Now,
                    RepoLink = createProjectViewModel.RepoLink,
                    Progress = 0
                };
                _projRepo.AddProj(proj);
                return RedirectToAction("Index", "Project", new { id = proj.ProjectId });
            }
            return View(createProjectViewModel);
        }

        public async Task<ViewResult> SearchProjects()
        {
            ICollection<Project> projects = _projRepo.GetProjs(ProjSearchCriteria.ByOpenDate, ProjSearchCriteria.OpenOnly, null);
            foreach (Project proj in projects)
            {
                proj.Valuation = _projRepo.GetValuationById(proj.ProjectId);
            }
            SearchProjectsViewModel searchProjectsViewModel = new SearchProjectsViewModel
            {
                Projects = projects,
                CurrentUser = await _userManager.GetUserAsync(User)
            };
            return View(searchProjectsViewModel);
        }

        [HttpPost]
        public async Task<ViewResult> SearchProjects(SearchProjectsViewModel searchProjectsViewModel)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            ICollection<Project> projects = _projRepo.GetProjs(searchProjectsViewModel.SortBy,
                                               searchProjectsViewModel.StatusFilter, searchProjectsViewModel.KeyWords);
            foreach (Project proj in projects)
            {
                proj.Valuation = _projRepo.GetValuationById(proj.ProjectId);
            }
            searchProjectsViewModel.Projects = projects;
            searchProjectsViewModel.CurrentUser = await _userManager.GetUserAsync(User); //we can't pass current user from the view using "<input type="hidden" asp-for="CurrentUser", we can only pass string/int
            return View(searchProjectsViewModel);
        }

        public ViewResult UpdateProject(int id)
        {
            var proj = _projRepo.GetProjById(id);
            CryptcurValue cryptcurValue = _projRepo.GetValuationById(id);
            CreateProjectViewModel createProjectViewModel = new CreateProjectViewModel
            {
                ProjId = id,
                ProjName = proj.ProjName,
                BriefDescript = proj.BriefDescript,
                ProtdCompDate = proj.ProtdCompDate,
                FullDescript = proj.FullDescript,
                Progress = proj.Progress,
                RepoLink = proj.RepoLink,
                Value_bitcoin = cryptcurValue.BitcoinValue,
                Value_ethereum = cryptcurValue.EthereumValue,
                Value_litecoin = cryptcurValue.LitecoinValue,
                Visibility = proj.Visibility,
                Status = proj.Status
            };
            return View(createProjectViewModel);
        }

        [HttpPost]
        public IActionResult UpdateProject(CreateProjectViewModel createProjectViewModel)
        {
            var proj = _projRepo.GetProjById(createProjectViewModel.ProjId);
            CryptcurValue cryptcurValue = _projRepo.GetValuationById(proj.ProjectId);
            cryptcurValue.BitcoinValue = createProjectViewModel.Value_bitcoin;
            cryptcurValue.EthereumValue = createProjectViewModel.Value_ethereum;
            cryptcurValue.LitecoinValue = createProjectViewModel.Value_litecoin;

            if (ModelState.IsValid)
            {
                proj.ProtdCompDate = createProjectViewModel.ProtdCompDate;
                proj.FullDescript = createProjectViewModel.FullDescript;
                proj.Progress = createProjectViewModel.Progress;
                proj.RepoLink = createProjectViewModel.RepoLink;
                proj.Visibility = createProjectViewModel.Visibility;
                proj.Status = createProjectViewModel.Status;
                proj.Valuation = cryptcurValue;
                _projRepo.SaveChanges();
                return RedirectToAction("Index", "Project", new { id = proj.ProjectId });
            }

            return View(createProjectViewModel);
        }

        public async Task<IActionResult> Like(int projId)
        {
            var thisProj = _projRepo.GetProjById(projId);
            var thisUser = await _userManager.GetUserAsync(User);
            Like like = new Like
            {
                MyProj = thisProj,
                Liker = thisUser,
                Timestamp = DateTime.Now,
                IsVisitor = false
            };
            _likeRepo.AddThisLike(like);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public async Task<IActionResult> Follow(int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            _projRepo.AddAFollower(thisUser, projId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public async Task<IActionResult> Unfollow(int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            _projRepo.RemoveAFollower(thisUser, projId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public async Task<IActionResult> Watch(int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            _projRepo.AddAWatcher((Buyer)thisUser, projId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public async Task<IActionResult> Unwatch(int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            _projRepo.RemoveAWatcher((Buyer)thisUser, projId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public ViewResult TalkToBuyers(int projId)
        {
            ICollection<Buyer> buyersToTalkTo = _projRepo.GetMyWatchersById(projId);
            foreach (var buyer in buyersToTalkTo)
            {
                if (!_negoRepo.BuyerHasNegoWithProj(buyer.Id, projId))
                    buyersToTalkTo.Remove(buyer);
            }
            //only pass buyers who are watching this proj and have conversation saved in db
            NegoViewModel negoViewMode = new NegoViewModel
            {
                Buyers = buyersToTalkTo,
                ProjId = projId
            };

            return View(negoViewMode);
        }

        public async Task<ViewResult> NegoWithBuyer(int buyerId, int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            var NegoEntries = _negoRepo.GetNegoEntriesByBuyerProjId(buyerId, projId);
            string previousNegoConver = null;
            foreach (var entry in NegoEntries)
            {
                previousNegoConver += entry.UserNickName + ": " + entry.Text + "\n";
            }
            NegoViewModel negoViewMode = new NegoViewModel
            {
                BuyerId = buyerId,
                CurrentUser = thisUser,
                ProjId = projId,
                PreviousNegoConver = previousNegoConver
            };
            return View(negoViewMode);
        }

        public IActionResult DismissADev(int id, int devId)
        {
            _projRepo.DismissADev(id, devId);
            return RedirectToAction("Index", "Project", new { id = id });
        }
        
    }
}