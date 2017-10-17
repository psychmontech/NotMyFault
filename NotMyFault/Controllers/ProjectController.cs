using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using NotMyFault.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<User> _userManager;
        public IProjRepo _ProjRepo { get; set; }
        public ProjectController(UserManager<User> userManager, IProjRepo ProjRepo)
        {
            _userManager = userManager;
            _ProjRepo = ProjRepo;
        }
        public ViewResult Index(int id)
        {
            var projectDevViewModel = new ProjectDevViewModel
            {
                ProjName = _ProjRepo.GetProjnameById(id),
                BriefDescript = _ProjRepo.GetBriefDesById(id),
                Progress = _ProjRepo.GetProgressById(id),
                Capacity = _ProjRepo.GetCapacityById(id),
                RepoLink = _ProjRepo.GetRepoLinkById(id),
                ProtdCompDate = _ProjRepo.GetProCompDateById(id),
                ProjLeader = _ProjRepo.GetProjLeaderById(id),
                MyDevs = _ProjRepo.GetMyDevsById(id),
                ProjStartingDate = DateTime.Now
            };
            //System.Diagnostics.Debug.WriteLine("$$$$$$$$$$$$$$$$$$$$$" + "Hello world");
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
                User user = await _userManager.GetUserAsync(User);
                Developer thisDev = (Developer)user;
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
                _ProjRepo.SaveProj(proj);
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
    }
}
