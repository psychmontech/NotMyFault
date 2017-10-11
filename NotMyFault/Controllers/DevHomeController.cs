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
        public int UserId { get; set; }
        public DevHomeController(IDevRepo DevRepo, IHttpContextAccessor httpContextAccessor)
        {
            _DevRepo = DevRepo;
            _HttpContextAccessor = httpContextAccessor;
            UserId = Int32.Parse(_HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public ViewResult Index()
        {
            var devHomeViewModel = new DevHomeViewModel
            {
                MyLeadingProjects = _DevRepo.GetMyLeadingProjsById(UserId),
                MyInvolvedProjects = _DevRepo.GetMyProjsById(UserId),
                MyFollowingProjects = _DevRepo.GetMyFollowingsById(UserId),
                MyEndors= _DevRepo.GetEndorsById(UserId),
            };
            //System.Diagnostics.Debug.WriteLine(devHomeViewModel.MyLeadingProjects[1].ProjName);
            return View(devHomeViewModel);  
        }
    }
}
