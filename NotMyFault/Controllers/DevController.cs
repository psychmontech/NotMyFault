using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class DevController : Controller
    {
        public IDevRepo _DevRepo { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public DevController(IDevRepo DevRepo, UserManager<User> userManager, ILogger<ProjectController> logger)
        {
            _DevRepo = DevRepo;
            _userManager = userManager;
            _logger = logger;
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
            return View(devHomeViewModel);  
        }

        public IActionResult ViewDevProfile(int id)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            Developer dev = _DevRepo.GetDevById(id);
            ViewDevProfileViewModel viewUserProfileViewModel = new ViewDevProfileViewModel
            {
                UserName = dev.UserName,
                NickName = dev.NickName,
                Thumbnail = dev.Thumbnail,
                Country = dev.Country,
                Region = dev.Region,
                SelfIntro = dev.SelfIntro,
                LinkedinUrl = dev.LinkedinUrl,
                NumProjWrkOn = _DevRepo.GetNumProjWrkOnById(id),
                Credit = _DevRepo.GetCreditById(id)
            };
            return View(viewUserProfileViewModel);
        }
    }
}
