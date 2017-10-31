using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Create(int projId)
        {
            ViewBag.ProjId = projId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecruitViewModel createRecruitViewModel)
        {
            Recruitment recruitment = new Recruitment
            {
                MyProj = _ProjRepo.GetProjById(createRecruitViewModel.ProjId),
                NameOfTheRole = createRecruitViewModel.NameOfTheRole,
                RoleDescription = createRecruitViewModel.RoleDescription,
                RequirDes = createRecruitViewModel.RequirDes,
                MaxNumPrjWkOn = createRecruitViewModel.MaxProjWkon,
                MinCredit = createRecruitViewModel.MinCredit,
                IsOpen = true
            };
            return View(createRecruitViewModel);
        }
    }
}
