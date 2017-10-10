using Microsoft.AspNetCore.Mvc;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.Repository;
using NotMyFault.Models.UserRelated;
using NotMyFault.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;

namespace NotMyFault.Controllers
{
    public class DevHomeController : Controller
    {
        public IDevRepo _DevRepo { get; set; }
        public IHttpContextAccessor _HttpContextAccessor { get; set; }
        public DevHomeController(IDevRepo DevRepo, IHttpContextAccessor httpContextAccessor)
        {
            _DevRepo = DevRepo;
            _HttpContextAccessor = httpContextAccessor;
        }
        public ViewResult Index()
        {
            int userId = Int32.Parse(_HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var devHomeViewModel = new DevHomeViewModel
            {
                MyLeadingProjects = _DevRepo.GetMyLeadingProjsById(userId),
                MyInvolvedProjects = _DevRepo.GetMyProjsById(userId),
                MyFollowingProjects = _DevRepo.GetMyFollowingsById(userId),
                MyEndors= _DevRepo.GetEndorsById(userId),
            };
            //System.Diagnostics.Debug.WriteLine(devHomeViewModel.MyLeadingProjects[1].ProjName);
            return View(devHomeViewModel);  
        }
    }
}
