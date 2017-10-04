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

        public List<Developer> Devs => _appDbContext.Devs.Include(c => c.Id).OrderBy(x => x.Id).ToList();
        public Developer GetDevById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id);
        public string GetUsernameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).UserName;
        public int GetNumProjWrkOnById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).NumProjWrkOn;
        public string GetCountryById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Country;
        public int GetRoleById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Role;
        public int GetCreditById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Credit;
        public string GetEmailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).Email;
        public List<Endorsment> GetEndorsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyEndors;
        public int GetIdByName(string Name) => _appDbContext.Devs.FirstOrDefault(p => p.UserName == Name).Id;
        public string GetLinkedinById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).LinkedinUrl;
        public List<DeveloperRecruitment> GetMyAppliedRolesById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyAppliedRoles;
        public BankDetails GetMyBankDetailsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyBankDetails;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyFollowings;
        public List<Project> GetMyLeadingProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyLeadingProjs;
        public List<DeveloperProject> GetMyProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyProjs;
        public List<Review> GetMyReviewsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MyReviews;
        public string GetMySkillsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).SelfIntro;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Id == id).MySupNAlleg;
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

        public void SetMySkillsById(int id, string selfintro)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Id == id).SelfIntro = selfintro;
            _appDbContext.SaveChanges();
        }
    }
}
