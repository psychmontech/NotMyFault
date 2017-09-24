using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Misce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using NotMyFault.Models.Repository.Interface;

namespace NotMyFault.Models.Repository
{
    public class DevRepo : IDevRepo
    {
        private readonly AppDbContext _appDbContext;

        public DevRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Developer> Devs => _appDbContext.Devs.Include(c => c.Userid).OrderBy(x => x.Userid).ToList();
        public Developer GetDevById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id);
        public string GetUsernameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Username;
        public int GetAgeById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Age;
        public string GetCountryById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Country;
        public int GetCreditById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Credit;
        public string GetEmailAddrById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).EmailAddr;
        public List<Endorsment> GetEndorsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyEndors;
        public int GetIdByName(string Name) => _appDbContext.Devs.FirstOrDefault(p => p.Username == Name).Userid;
        public string GetLinkedinById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).LinkedinUrl;
        public List<DeveloperRecruitment> GetMyAppliedRolesById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyAppliedRoles;
        public BankDetails GetMyBankDetailsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyBankDetails;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyFollowings;
        public List<Project> GetMyLeadingProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyLeadingProjs;
        public List<DeveloperProject> GetMyProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyProjs;
        public List<Review> GetMyReviewsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MyReviews;
        public string GetMySkillsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).SelfIntro;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).MySupNAlleg;
        public string GetNickNameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Nickname;
        public string GetRegionById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Thumbnail;

        public void SetLinkedinById(int id, string linkedinUrl)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).LinkedinUrl = linkedinUrl;
            _appDbContext.SaveChanges();
        }

        public void SetAgeById(int id, int age)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Age= age;
            _appDbContext.SaveChanges();
        }

        public void SetEmailAddrById(int id, string emailAddr)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).EmailAddr = emailAddr;
            _appDbContext.SaveChanges();
        }

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Username = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Nickname = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).Thumbnail= thumbnail;
            _appDbContext.SaveChanges();
        }

        public void SetMySkillsById(int id, string selfintro)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.Userid == id).SelfIntro = selfintro;
            _appDbContext.SaveChanges();
        }
    }
}
