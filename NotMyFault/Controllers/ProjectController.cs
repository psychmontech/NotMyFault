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

namespace NotMyFault.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<User> _userManager;
        public IProjRepo _projRepo { get; set; }
        public ILikeRepo _likeRepo { get; set; }
        private readonly ILogger _logger;
        public ProjectController(UserManager<User> userManager, IProjRepo ProjRepo, ILogger<ProjectController> logger,
                                ILikeRepo LikeRepo)
        {
            _userManager = userManager;
            _projRepo = ProjRepo;
            _likeRepo = LikeRepo;
            _logger = logger;
        }
        public async Task<ViewResult> Index(int id)
        {
            var proj = _projRepo.GetProjById(id);
            var thisUser = await _userManager.GetUserAsync(User);
            ProjectViewModel projectViewModel = null;
            if (thisUser.Role == UserRole.Dev)
            {
                projectViewModel = new ProjectViewModel
                {
                    Proj = proj,
                    CurrentUser = (Developer)thisUser,
                    Capacity = _projRepo.GetCapacityById(id),
                    ProjLeader = _projRepo.GetProjLeaderById(id),
                    MyDevs = _projRepo.GetMyDevsById(id),
                    NumOfFollowers = _projRepo.GetMyFollowersById(id).Count,
                    NumOfLikes = _projRepo.GetMyLikesById(id).Count,
                    CurrentDevIsInvolved = _projRepo.ThisDevIsInvolved(thisUser, id),
                    CurrentUserHasLiked = _projRepo.ThisUserHasLiked(thisUser, id),
                    CurrentUserHasFollowed = _projRepo.ThisUserHasFollowed(thisUser, id),
                    CurrentBuyerHasWatched = false,
                    HasOpenRecruits = _projRepo.HasOpenRecruits(id)
                };
            }
            else
            {
                projectViewModel = new ProjectViewModel
                {
                    Proj = proj,
                    CurrentUser = (Buyer)thisUser,
                    Capacity = _projRepo.GetCapacityById(id),
                    ProjLeader = _projRepo.GetProjLeaderById(id),
                    MyDevs = _projRepo.GetMyDevsById(id),
                    NumOfFollowers = _projRepo.GetMyFollowersById(id).Count,
                    NumOfLikes = _projRepo.GetMyLikesById(id).Count,
                    CurrentDevIsInvolved = false,
                    CurrentUserHasLiked = _projRepo.ThisUserHasLiked(thisUser, id),
                    CurrentUserHasFollowed = _projRepo.ThisUserHasFollowed(thisUser, id),
                    CurrentBuyerHasWatched = _projRepo.ThisBuyerHasWatched(thisUser, id),
                    HasOpenRecruits = _projRepo.HasOpenRecruits(id)
                };
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
                Developer thisDev = (Developer) await _userManager.GetUserAsync(User);
                ICollection<DeveloperProject> devproj = new List<DeveloperProject> { new DeveloperProject { Dev = thisDev } };
                Project proj = new Project
                {
                    ProjName = createProjectViewModel.ProjName,
                    BriefDescript = createProjectViewModel.BriefDescript,
                    FullDescript = createProjectViewModel.FullDescript,
                    Valuation = createProjectViewModel.Valuation,
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
            SearchProjectsViewModel searchProjectsViewModel = new SearchProjectsViewModel
            {
                Projects = _projRepo.GetProjs(ProjSearchCriteria.ByOpenDate, ProjSearchCriteria.OpenOnly, null),
                CurrentUser = await _userManager.GetUserAsync(User)
        };
            return View(searchProjectsViewModel);
        }

        [HttpPost]
        public async Task<ViewResult> SearchProjects(SearchProjectsViewModel searchProjectsViewModel)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            searchProjectsViewModel.Projects = _projRepo.GetProjs(searchProjectsViewModel.SortBy, 
                                               searchProjectsViewModel.StatusFilter, searchProjectsViewModel.KeyWords);
            searchProjectsViewModel.CurrentUser = await _userManager.GetUserAsync(User); //we can't pass current user from the view using "<input type="hidden" asp-for="CurrentUser", we can only pass string/int
            return View(searchProjectsViewModel);
        }

        public ViewResult UpdateProject(int id)
        {
            var proj = _projRepo.GetProjById(id);
            CreateProjectViewModel createProjectViewModel = new CreateProjectViewModel
            {
                ProjId = id,
                ProjName = proj.ProjName,
                BriefDescript = proj.BriefDescript,
                ProtdCompDate = proj.ProtdCompDate,
                FullDescript = proj.FullDescript,
                Progress = proj.Progress,
                RepoLink = proj.RepoLink,
                Valuation = proj.Valuation,
                Visibility = proj.Visibility,
                Status = proj.Status
            };
            return View(createProjectViewModel);
        }

        [HttpPost]
        public IActionResult UpdateProject(CreateProjectViewModel createProjectViewModel)
        {
            var proj = _projRepo.GetProjById(createProjectViewModel.ProjId);

            if (ModelState.IsValid)
            {
                proj.ProtdCompDate = createProjectViewModel.ProtdCompDate;
                proj.FullDescript = createProjectViewModel.FullDescript;
                proj.Progress = createProjectViewModel.Progress;
                proj.RepoLink = createProjectViewModel.RepoLink;
                proj.Valuation = createProjectViewModel.Valuation;
                proj.Visibility = createProjectViewModel.Visibility;
                proj.Status = createProjectViewModel.Status;

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

        public async Task<IActionResult> Watch(int projId)
        {
            var thisUser = await _userManager.GetUserAsync(User);
            _projRepo.AddAWatcher((Buyer)thisUser, projId);
            return RedirectToAction("Index", "Project", new { id = projId });
        }
    }
}
