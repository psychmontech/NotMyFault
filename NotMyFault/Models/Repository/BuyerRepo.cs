using NotMyFault.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.ProjRelated;
using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.UserRelated;
using NotMyFault.Models.Repository.Interface;

namespace NotMyFault.Models.Repository
{
    public class BuyerRepo : IBuyerRepo
    {
        private readonly AppDbContext _appDbContext;

        public BuyerRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Buyer> Buyers => _appDbContext.Buyers.Include(c => c.Id).OrderBy(x => x.Id).ToList();
        public Buyer GetBuyerById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id);
        public int GetIdByName(string Name) => _appDbContext.Buyers.FirstOrDefault(p => p.UserName == Name).Id;
        public string GetUsernameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).UserName;
        public int GetRoleById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Role;
        public string GetNickNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).NickName;
        public string GetEmailById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Email;
        public string GetRegionById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Thumbnail;
        public string GetCountryById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Country;
        public string GetCompNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).CompanyName;
        public string GetCompAddrById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).CompanyAddr;
        public int GetEarnestById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Earnest;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).MyFollowings;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).MySupNAlleg;
        public List<BuyerProject> GetProjsUnderNego(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).ProjsUnderNego;
        public List<Negotiation> GetMyNegos(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).MyNegos;

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).UserName = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).NickName = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Thumbnail = thumbnail;
            _appDbContext.SaveChanges();
        }
        
        public void SetEarnestById(int id, int earnest)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Id == id).Earnest= earnest;
            _appDbContext.SaveChanges();
        }
    }
}
