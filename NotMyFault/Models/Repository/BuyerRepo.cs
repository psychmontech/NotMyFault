using NotMyFault.Models.Misce;
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

        public List<Buyer> Buyers => _appDbContext.Buyers.Include(c => c.Userid).OrderBy(x => x.Userid).ToList();
        public Buyer GetBuyerById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id);
        public int GetIdByName(string Name) => _appDbContext.Buyers.FirstOrDefault(p => p.Username == Name).Userid;
        public string GetUsernameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Username;
        public string GetNickNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Nickname;
        public string GetRegionById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Thumbnail;
        public string GetCountryById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Country;
        public string GetCompNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).CompanyName;
        public string GetCompAddrById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).CompanyAddr;
        public int GetEarnestById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Earnest;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).MyFollowings;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).MySupNAlleg;
        public List<BuyerProject> GetProjsUnderNego(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).ProjsUnderNego;
        public List<Negotiation> GetMyNegos(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).MyNegos;

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Username = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Nickname = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Thumbnail = thumbnail;
            _appDbContext.SaveChanges();
        }
        
        public void SetEarnestById(int id, int earnest)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.Userid == id).Earnest= earnest;
            _appDbContext.SaveChanges();
        }
    }
}
