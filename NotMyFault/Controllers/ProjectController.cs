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
            var thisDev = (Developer)thisUser;
            var projectDevViewModel = new ProjectDevViewModel
            {
                projId = id,
                ProjName = proj.ProjName,
                BriefDescript = proj.BriefDescript,
                Progress = proj.Progress,
                RepoLink = proj.RepoLink,
                Valuation = proj.Valuation,
                Status = proj.Status,
                ProtdCompDate = proj.ProtdCompDate,
                ProjStartingDate = proj.StartingDate,
                Capacity = _projRepo.GetCapacityById(id),
                ProjLeader = _projRepo.GetProjLeaderById(id),
                MyDevs = _projRepo.GetMyDevsById(id),
                FullDescript = proj.FullDescript,
                NumOfFollowers = _projRepo.GetMyFollowersById(id).Count,
                NumOfLikes = _projRepo.GetMyLikesById(id).Count,
                CurrentDev = thisDev,
                CurrentDevIsInvolved = _projRepo.ThisDevIsInvolved(thisDev, id),
                CurrentUserHasLiked = _projRepo.ThisUserHasLiked(thisDev, id),
                CurrentUserHasFollowed = _projRepo.ThisUserHasFollowed(thisUser, id),
                HasOpenRecruits = _projRepo.HasOpenRecruits(id)
            };
            return View(projectDevViewModel);
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

        public ViewResult SearchProjects()
        {
            SearchProjectsViewModel searchProjectsViewModel = new SearchProjectsViewModel
            {
                Projects = _projRepo.GetProjs(ProjSearchCriteria.ByOpenDate, ProjSearchCriteria.OpenOnly, null)
            };
            return View(searchProjectsViewModel);
        }

        [HttpPost]
        public ViewResult SearchProjects(SearchProjectsViewModel searchProjectsViewModel)
        {
            searchProjectsViewModel.Projects = _projRepo.GetProjs(searchProjectsViewModel.SortBy, searchProjectsViewModel.StatusFilter, searchProjectsViewModel.KeyWords);
            return View(searchProjectsViewModel);
        }

        public ViewResult UpdateProject(int id)
        {
            var proj = _projRepo.GetProjById(id);
            UpdateProjectViewModel updateProjectViewModel = new UpdateProjectViewModel
            {
                ProjId = id,
                ProtdCompDate = proj.ProtdCompDate,
                FullDescript = proj.FullDescript,
                Progress = proj.Progress,
                RepoLink = proj.RepoLink,
                Valuation = proj.Valuation,
                Visibility = proj.Visibility,
                Status = proj.Status
            };
            return View(updateProjectViewModel);
        }

        [HttpPost]
        public IActionResult UpdateProject(UpdateProjectViewModel updateProjectViewModel)
        {
            var proj = _projRepo.GetProjById(updateProjectViewModel.ProjId);

            if (ModelState.IsValid)
            {
                proj.ProtdCompDate = updateProjectViewModel.ProtdCompDate;
                proj.FullDescript = updateProjectViewModel.FullDescript;
                proj.Progress = updateProjectViewModel.Progress;
                proj.RepoLink = updateProjectViewModel.RepoLink;
                proj.Valuation = updateProjectViewModel.Valuation;
                proj.Visibility = updateProjectViewModel.Visibility;
                proj.Status = updateProjectViewModel.Status;

                _projRepo.SaveChanges();
                return RedirectToAction("Index", "Project", new { id = proj.ProjectId });
            }

            return View(updateProjectViewModel);
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
    }
}
