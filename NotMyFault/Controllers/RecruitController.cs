using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class RecruitController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private IRecruitRepo _recruitRepo;
        private IDevRepo _devRepo;
        public IProjRepo _ProjRepo { get; set; }

        public RecruitController(UserManager<User> userManager, SignInManager<User> signInManager, IProjRepo ProjRepo,
                                 IDevRepo devRepo, ILogger<ProjectController> logger, IRecruitRepo recruitRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _recruitRepo = recruitRepo;
            _ProjRepo = ProjRepo;
            _devRepo = devRepo;
        }

        public async Task<ViewResult> Index(int id)
        {
            var recruit = _recruitRepo.GetRecruitById(id);
            var thisDev = (Developer) await _userManager.GetUserAsync(User);
            var viewRecruitViewModel = new ViewRecruitViewModel()
            {
                MyProj = recruit.MyProj,
                NameOfTheRole = recruit.NameOfTheRole,
                RoleDescription = recruit.RoleDescription,
                RequirDescript = recruit.RequirDescript,
                MinCredit = recruit.MinCredit,
                MaxNumPrjWkOn = recruit.MaxNumPrjWkOn,
                IsOpen = recruit.IsOpen,
                DateCreated = recruit.DateCreated,
                Candidates = _recruitRepo.GetCandiesByRecruId(id),
                RecruitId = id,
                CurrentDev = thisDev,
                CurrentDevIsInvolved = _ProjRepo.ThisDevIsInvolved(thisDev, recruit.MyProj.ProjectId),
                CurrentDevIsLeader = thisDev == _ProjRepo.GetProjLeaderById(recruit.MyProj.ProjectId),
                CurrentDevHasApplied = _recruitRepo.ThisDevHasApplied(id, thisDev),
                CurrentDevIsEligibleToApply = (_devRepo.GetNumProjWrkOnById(thisDev.Id) <= recruit.MaxNumPrjWkOn || recruit.MaxNumPrjWkOn == 0)
                                               && (_devRepo.GetCreditById(thisDev.Id) >= recruit.MinCredit)
            };
            return View(viewRecruitViewModel);
        }

        public IActionResult CreateRecruit(int projId)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", projId);
            var createRecruitViewModel = new CreateRecruitViewModel
            {
                ProjId = projId
            };
            return View(createRecruitViewModel);
        }

        [HttpPost]
        public IActionResult CreateRecruit(CreateRecruitViewModel createRecruitViewModel)
        {
            if (ModelState.IsValid)
            {
                Recruitment recruitment = new Recruitment
                {
                    MyProj = _ProjRepo.GetProjById(createRecruitViewModel.ProjId),
                    NameOfTheRole = createRecruitViewModel.NameOfTheRole,
                    RoleDescription = createRecruitViewModel.RoleDescription,
                    RequirDescript = createRecruitViewModel.RequirDescript,
                    MaxNumPrjWkOn = createRecruitViewModel.MaxProjWkon,
                    MinCredit = createRecruitViewModel.MinCredit,
                    IsOpen = true,
                    DateCreated = DateTime.Now
                };
                _recruitRepo.AddRecruit(recruitment);
                return RedirectToAction("Index", "Project", new { id = createRecruitViewModel.ProjId });
            }
            return View(createRecruitViewModel);
        }

        public ViewResult SearchRecruit()
        {
            SearchRecruitViewModel searchRecruitViewModel = new SearchRecruitViewModel
            {
                Recruits = _recruitRepo.GetAllRecruits()
            };
            return View(searchRecruitViewModel);
        }

        [HttpPost]
        public ViewResult SearchRecruit(SearchRecruitViewModel searchRecruitViewModel)
        {
            searchRecruitViewModel.Recruits = _recruitRepo.GetRecruitsByKeywords(searchRecruitViewModel.KeyWords);
            return View(searchRecruitViewModel);
        }

        public async Task<IActionResult> Apply(int id)
        {
            var thisDev = (Developer)await _userManager.GetUserAsync(User);
            _recruitRepo.AddACandy(id, thisDev);
            return  RedirectToAction("Index", "Recruit", new { id });
        } 

        public IActionResult Accept(int id, int projId, int devId)
        {
            Developer dev = _devRepo.GetDevById(devId);
            _ProjRepo.AddADev(projId, dev);
            if (_ProjRepo.ThisUserHasFollowed(dev, projId))
                _ProjRepo.RemoveAFollower(dev, projId);
            _recruitRepo.GetRecruitById(id).IsOpen = false;
            _recruitRepo.RemoveAllCandies(id); //this includes "_recruitRepo.SaveChanges()" which saves the changes made in the statement above
            return RedirectToAction("Index", "Project", new { id = projId });
        }

        public ViewResult ListRecruits(int projId)
        {
            SearchRecruitViewModel searchRecruitViewModel = new SearchRecruitViewModel
            {
                Recruits = _ProjRepo.GetMyRecruitsById(projId)
            };
            ViewBag.ProjId = projId;
            return View(searchRecruitViewModel);
        }

        public ViewResult EditRecruit(int id)
        {
            var recruit = _recruitRepo.GetRecruitById(id);
            CreateRecruitViewModel createRecruitViewModel = new CreateRecruitViewModel
            {
                ProjId = id,  //we are using projId as recruitId here
                NameOfTheRole = recruit.NameOfTheRole,
                RoleDescription = recruit.RoleDescription,
                RequirDescript = recruit.RequirDescript,
                MaxProjWkon = recruit.MaxNumPrjWkOn,
                MinCredit = recruit.MinCredit,
            };
            return View(createRecruitViewModel);
        }

        [HttpPost]
        public IActionResult EditRecruit(CreateRecruitViewModel createRecruitViewModel)
        {
            if (ModelState.IsValid)
            {
                var recruit = _recruitRepo.GetRecruitById(createRecruitViewModel.ProjId); //we are using projId as recruitId here
                if (ModelState.IsValid)
                {
                    recruit.NameOfTheRole = createRecruitViewModel.NameOfTheRole;
                    recruit.RoleDescription = createRecruitViewModel.RoleDescription;
                    recruit.RequirDescript = createRecruitViewModel.RequirDescript;
                    recruit.MaxNumPrjWkOn = createRecruitViewModel.MaxProjWkon;
                    recruit.MinCredit = createRecruitViewModel.MinCredit;
                }

                _recruitRepo.SaveChanges();
                return RedirectToAction("Index", "Recruit", new { id = createRecruitViewModel.ProjId }); 
            }
            return View(createRecruitViewModel);
        }

        public IActionResult RemoveRecruit(int id, int ProjId)
        {
            _recruitRepo.RemoveRecruit(id);
            return RedirectToAction("ListRecruits", "Recruit", new { projId = ProjId });
        }

        public async Task<IActionResult> Withdraw(int id)
        {
            var thisDev = (Developer)await _userManager.GetUserAsync(User);
            _recruitRepo.RemoveACandy(id, thisDev);
            return RedirectToAction("Index", "Recruit", new { id });
        }
    }
}
