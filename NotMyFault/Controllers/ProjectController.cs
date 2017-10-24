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
        public IProjRepo _ProjRepo { get; set; }
        private readonly ILogger _logger;
        public ProjectController(UserManager<User> userManager, IProjRepo ProjRepo, ILogger<ProjectController> logger)
        {
            _userManager = userManager;
            _ProjRepo = ProjRepo;
            _logger = logger;
        }
        public async Task<ViewResult> Index(int id)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            var proj = _ProjRepo.GetProjById(id);
            var thisDev = (Developer) await _userManager.GetUserAsync(User);
            _logger.LogCritical(1002, "Getting item {ID}", _ProjRepo.IsThisDevInvolved(thisDev, id));
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
                Capacity = _ProjRepo.GetCapacityById(id),
                ProjLeader = _ProjRepo.GetProjLeaderById(id),
                MyDevs = _ProjRepo.GetMyDevsById(id),
                FullDescript = proj.FullDescript,
                IsCurrentDevInvolved = _ProjRepo.IsThisDevInvolved(thisDev, id)
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
                _ProjRepo.AddProj(proj);
                return RedirectToAction("Index", "Project", new { id = proj.ProjectId });
            }
            return View(createProjectViewModel);
        }

        public ViewResult SearchProjects()
        {
            SearchProjectsViewModel searchProjectsViewModel = new SearchProjectsViewModel
            {
                Projects = _ProjRepo.GetProjs(ProjSearchCriteria.ByOpenDate, ProjSearchCriteria.OpenOnly, null)
            };
            return View(searchProjectsViewModel);
        }

        [HttpPost]
        public ViewResult SearchProjects(SearchProjectsViewModel searchProjectsViewModel)
        {
            SearchProjectsViewModel searchProjectsViewModel_New = new SearchProjectsViewModel
            {
                Projects = _ProjRepo.GetProjs(searchProjectsViewModel.SortBy, searchProjectsViewModel.StatusFilter, searchProjectsViewModel.KeyWords)
            };
            return View(searchProjectsViewModel_New);
        }

        public ViewResult UpdateProject(int id)
        {
            var proj = _ProjRepo.GetProjById(id);
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
            var proj = _ProjRepo.GetProjById(updateProjectViewModel.ProjId);

            if (ModelState.IsValid)
            {
                proj.ProtdCompDate = updateProjectViewModel.ProtdCompDate;
                proj.FullDescript = updateProjectViewModel.FullDescript;
                proj.Progress = updateProjectViewModel.Progress;
                proj.RepoLink = updateProjectViewModel.RepoLink;
                proj.Valuation = updateProjectViewModel.Valuation;
                proj.Visibility = updateProjectViewModel.Visibility;
                proj.Status = updateProjectViewModel.Status;

                _ProjRepo.UpdateProj(proj);
                return RedirectToAction("Index", "Project", new { id = proj.ProjectId });
            }

            return View(updateProjectViewModel);
        }
    }
}
