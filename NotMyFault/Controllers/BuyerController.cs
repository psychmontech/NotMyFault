using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using System.Threading.Tasks;

namespace NotMyFault.Controllers
{
    public class BuyerController : Controller
    {
        public IBuyerRepo _BuyerRepo { get; set; }
        private readonly UserManager<User> _userManager;
        private readonly ILogger _logger;

        public BuyerController(IBuyerRepo BuyerRepo, UserManager<User> userManager, ILogger<ProjectController> logger)
        {
            _BuyerRepo = BuyerRepo;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHomeViewModel = new UserHomeViewModel
            {
                MyFollowingProjects = _BuyerRepo.GetMyFollowingsById(user.Id),
                MyWatchingProjects = _BuyerRepo.GetMyWatchingProjs(user.Id),
            };
            return View(userHomeViewModel);
        }

        public IActionResult ViewBuyerProfile(int id)
        {
            _logger.LogCritical(1002, "Getting item {ID}", id);
            Buyer buyer = _BuyerRepo.GetBuyerById(id);
            ViewUserProfileViewModel viewUserProfileViewModel = new ViewUserProfileViewModel
            {
                CurrentBuyer = buyer
            };
            return View(viewUserProfileViewModel);
        }
    }
}
