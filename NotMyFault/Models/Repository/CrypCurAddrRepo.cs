using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class CrypCurAddrRepo : ICrypCurAddrRepo
    {
        private readonly AppDbContext _appDbContext;

        public CrypCurAddrRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public CrypCurAddr GetCrypCurAddrByUserId(int id) => _appDbContext.CrypCurAddr.Include(r => r.MyDev).FirstOrDefault(r => r.MyDev.Id == id);
    }
}