using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections;

namespace NotMyFault.Controllers
{
    public class RecruitController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        private IRecruitRepo _recruitRepo;
        public IProjRepo _ProjRepo { get; set; }

        public RecruitController(UserManager<User> userManager, SignInManager<User> signInManager, IProjRepo ProjRepo,
                                 ILogger<ProjectController> logger, IRecruitRepo recruitRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _recruitRepo = recruitRepo;
            _ProjRepo = ProjRepo;
        }

        public IActionResult CreateRecruit(int projId)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", projId);
            ViewBag.ProjId = projId;
            return View();
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
    }
}
