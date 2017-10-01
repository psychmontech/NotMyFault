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

        public List<Developer> Devs => _appDbContext.Devs.Include(c => c.UserId).OrderBy(x => x.UserId).ToList();
        public Developer GetDevById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id);
        public string GetUsernameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).UserName;
        public int GetNumProjWrkOnById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).NumProjWrkOn;
        public string GetCountryById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Country;
        public int GetCreditById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Credit;
        public string GetEmailAddrById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).EmailAddr;
        public List<Endorsment> GetEndorsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyEndors;
        public int GetIdByName(string Name) => _appDbContext.Devs.FirstOrDefault(p => p.UserName == Name).UserId;
        public string GetLinkedinById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).LinkedinUrl;
        public List<DeveloperRecruitment> GetMyAppliedRolesById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyAppliedRoles;
        public BankDetails GetMyBankDetailsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyBankDetails;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyFollowings;
        public List<Project> GetMyLeadingProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyLeadingProjs;
        public List<DeveloperProject> GetMyProjsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyProjs;
        public List<Review> GetMyReviewsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MyReviews;
        public string GetMySkillsById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).SelfIntro;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).MySupNAlleg;
        public string GetNickNameById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).NickName;
        public string GetRegionById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Thumbnail;

        public void SetLinkedinById(int id, string linkedinUrl)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).LinkedinUrl = linkedinUrl;
            _appDbContext.SaveChanges();
        }

        public void SetNumProjWrkOnById(int id, int num)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).NumProjWrkOn = num;
            _appDbContext.SaveChanges();
        }

        public void SetEmailAddrById(int id, string emailAddr)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).EmailAddr = emailAddr;
            _appDbContext.SaveChanges();
        }

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).UserName = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).NickName = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).Thumbnail= thumbnail;
            _appDbContext.SaveChanges();
        }

        public void SetMySkillsById(int id, string selfintro)
        {
            _appDbContext.Devs.FirstOrDefault(p => p.UserId == id).SelfIntro = selfintro;
            _appDbContext.SaveChanges();
        }
    }
}
