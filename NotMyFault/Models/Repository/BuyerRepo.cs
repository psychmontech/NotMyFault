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

        public List<Buyer> Buyers => _appDbContext.Buyers.Include(c => c.UserId).OrderBy(x => x.UserId).ToList();
        public Buyer GetBuyerById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id);
        public int GetIdByName(string Name) => _appDbContext.Buyers.FirstOrDefault(p => p.UserName == Name).UserId;
        public string GetUsernameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).UserName;
        public string GetNickNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).NickName;
        public string GetRegionById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Region;
        public byte GetThumbnailById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Thumbnail;
        public string GetCountryById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Country;
        public string GetCompNameById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).CompanyName;
        public string GetCompAddrById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).CompanyAddr;
        public int GetEarnestById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Earnest;
        public List<UserProject> GetMyFollowingsById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).MyFollowings;
        public List<SupptNAlleg> GetMySupNAllegById(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).MySupNAlleg;
        public List<BuyerProject> GetProjsUnderNego(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).ProjsUnderNego;
        public List<Negotiation> GetMyNegos(int id) => _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).MyNegos;

        public void SetUsernameById(int id, string username)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).UserName = username;
            _appDbContext.SaveChanges();
        }

        public void SetNickNameById(int id, string nickName)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).NickName = nickName;
            _appDbContext.SaveChanges();
        }

        public void SetCountryById(int id, string country)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Country = country;
            _appDbContext.SaveChanges();
        }

        public void SetRegionById(int id, string region)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Region = region;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Thumbnail = thumbnail;
            _appDbContext.SaveChanges();
        }
        
        public void SetEarnestById(int id, int earnest)
        {
            _appDbContext.Buyers.FirstOrDefault(p => p.UserId == id).Earnest= earnest;
            _appDbContext.SaveChanges();
        }
    }
}
