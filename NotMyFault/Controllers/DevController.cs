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
            var userHomeViewModel = new UserHomeViewModel
            {
                MyLeadingProjects = _DevRepo.GetMyLeadingProjsById(user.Id),
                MyInvolvedProjects = _DevRepo.GetMyProjsById(user.Id),
                MyFollowingProjects = _DevRepo.GetMyFollowingsById(user.Id),
                MyEndors= _DevRepo.GetEndorsById(user.Id),
            };
            return View(userHomeViewModel);  
        }

        public IActionResult ViewDevProfile(int id)
        {
            //_logger.LogCritical(1002, "Getting item {ID}", id);
            Developer dev = _DevRepo.GetDevById(id);
            ViewUserProfileViewModel viewUserProfileViewModel = new ViewUserProfileViewModel
            {
                CurrentDev = dev,
                NumProjWrkOn = _DevRepo.GetNumProjWrkOnById(id),
                Credit = _DevRepo.GetCreditById(id)
            };
            return View(viewUserProfileViewModel);
        }
    }
}
