using Microsoft.EntityFrameworkCore;
using NotMyFault.Constants;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using System.Collections.Generic;
using System.Linq;

namespace NotMyFault.Models.Repository
{
    public class DevRepo : IDevRepo
    {
        private readonly AppDbContext _appDbContext;

        public DevRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Developer> Devs => _appDbContext.Devs.Include(c => c.Id).OrderBy(x => x.Id).ToList();
        public Developer GetDevById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id);
        public string GetUsernameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).UserName;
        public int GetNumProjWrkOnById(int id) => _appDbContext.DevProjs.Where(p => p.Id == id).Select(pt => pt.Proj).Count();
        public string GetCountryById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Country;
        public int GetRoleById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Role;
        public string GetEmailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Email;
        public ICollection<Endorsment> GetEndorsById(int id) => _appDbContext.Endorsments.Include(P => P.MyDev).ToList().FindAll(c => c.MyDev.Id == id); 
        public int GetIdByName(string Name) => _appDbContext.Devs.FirstOrDefault(p => p.UserName == Name).Id;
        public string GetLinkedinById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).LinkedinUrl;
        public ICollection<Recruitment> GetMyAppliedRolesById(int id) => _appDbContext.DevRecruits.Where(p => p.Id == id).Select(pt => pt.Recruit).ToList(); 
        public CryptcurAddr GetCrypCurAddrById(int id) => _appDbContext.CryptcurAddrs.Include(P => P.MyUser).ToList().FirstOrDefault(c => c.MyUser.Id == id);
        public ICollection<Project> GetMyFollowingsById(int id) => _appDbContext.UserProjs.Where(p => p.Id == id).Select(pt => pt.Proj).ToList();
        public ICollection<Project> GetMyLeadingProjsById(int id) => _appDbContext.Projects.Include(P => P.ProjLeader).ToList().FindAll(c => c.ProjLeader.Id == id);   //look at me :)
        public ICollection<Project> GetMyProjsById(int id) => _appDbContext.DevProjs.Where(p => p.Id == id).Select(pt=>pt.Proj).ToList(); //look at me :))
        public ICollection<Project> GetMyCompletedProjsById(int id) => _appDbContext.DevProjs.Where(p => p.Id == id).Select(pt=>pt.Proj).ToList().FindAll(p=>p.ProjStatus == ProjStatus.Development_Completed); //look at me :))
        public ICollection<Review> GetMyReviewsById(int id) => _appDbContext.Reviews.Include(P => P.Reviewee).ToList().FindAll(c => c.Reviewee.Id == id);
        public string GetSelfIntroById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).SelfIntro;
        public ICollection<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.SupptNAllegs.Include(P => P.MyUser).ToList().FindAll(c => c.MyUser.Id == id);
        public string GetNickNameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NickName;
        public string GetRegionById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Thumbnail;
        public int GetCreditById(int id)
        {
            ICollection<Review> Reviews = GetMyReviewsById(id);
            int sum = 0;
            foreach (Review rev in Reviews)
            {
                sum += rev.Score;
            }
            return sum;
        }
    }
}
