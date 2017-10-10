using Microsoft.EntityFrameworkCore;
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
        public int GetNumProjWrkOnById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NumProjWrkOn;
        public string GetCountryById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Country;
        public int GetRoleById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Role;
        public int GetCreditById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Credit;
        public string GetEmailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Email;
        public ICollection<Endorsment> GetEndorsById(int id) => _appDbContext.Endorsments.Include(P => P.MyDev).ToList().FindAll(c => c.MyDev.Id == id); 
        public int GetIdByName(string Name) => _appDbContext.Devs.FirstOrDefault(p => p.UserName == Name).Id;
        public string GetLinkedinById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).LinkedinUrl;
        public ICollection<Recruitment> GetMyAppliedRolesById(int id) => _appDbContext.DevRecruits.Include(p => p.Recruit).Where(p => p.Id == id).Select(pt => pt.Recruit).ToList(); 
        public BankDetails GetMyBankDetailsById(int id) => _appDbContext.BankDetails.Include(P => P.MyDev).ToList().FirstOrDefault(c => c.MyDev.Id == id);
        public ICollection<Project> GetMyFollowingsById(int id) => _appDbContext.UserProjs.Include(p => p.Proj).Where(p => p.Id == id).Select(pt => pt.Proj).ToList();
        public ICollection<Project> GetMyLeadingProjsById(int id) => _appDbContext.Projects.Include(P => P.ProjLeader).ToList().FindAll(c => c.ProjLeader.Id == id);   //look at me :)
        public ICollection<Project> GetMyProjsById(int id) => _appDbContext.DevProjs.Include(p=> p.Proj).Where(p => p.Id == id).Select(pt=>pt.Proj).ToList(); //look at me :))
        public ICollection<Review> GetMyReviewsById(int id) => _appDbContext.Reviews.Include(P => P.MyReviewee).ToList().FindAll(c => c.MyReviewee.Id == id);
        public string GetSelfIntroById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).SelfIntro;
        public ICollection<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.SupptNAllegs.Include(P => P.MyUser).ToList().FindAll(c => c.MyUser.Id == id);
        public string GetNickNameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NickName;
        public string GetRegionById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Thumbnail;

        public void SetLinkedinById(int id, string linkedinUrl)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).LinkedinUrl = linkedinUrl;
            _appDbContext.SaveChanges();
        }

        public void SetNumProjWrkOnById(int id, int num)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NumProjWrkOn = num;
            _appDbContext.SaveChanges();
        }

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).UserName = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NickName = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Thumbnail= thumbnail;
            _appDbContext.SaveChanges();
        }

        public void SetSelfIntroById(int id, string selfintro)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).SelfIntro = selfintro;
            _appDbContext.SaveChanges();
        }
    }
}
