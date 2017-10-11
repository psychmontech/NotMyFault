using Microsoft.AspNetCore.Mvc;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.Repository;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;

namespace NotMyFault.Controllers
{
    public class DevHomeController : Controller
    {
        public IDevRepo _DevRepo { get; set; }
        public IHttpContextAccessor _HttpContextAccessor { get; set; }
        private readonly UserManager<User> _userManager;
        public DevHomeController(IDevRepo DevRepo, UserManager<User> userManager)
        {
            _DevRepo = DevRepo;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var devHomeViewModel = new DevHomeViewModel
            {
                MyLeadingProjects = _DevRepo.GetMyLeadingProjsById(user.Id),
                MyInvolvedProjects = _DevRepo.GetMyProjsById(user.Id),
                MyFollowingProjects = _DevRepo.GetMyFollowingsById(user.Id),
                MyEndors= _DevRepo.GetEndorsById(user.Id),
            };
            //System.Diagnostics.Debug.WriteLine(devHomeViewModel.MyLeadingProjects[1].ProjName);
            return View(devHomeViewModel);  
        }
    }
}
