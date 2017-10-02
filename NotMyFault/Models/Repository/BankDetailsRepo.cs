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
    public class BankDetailsRepo : IBankDetailsRepo
    {
        private readonly AppDbContext _appDbContext;

        public BankDetailsRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public BankDetails GetBkDetailsByUserId(int id) => _appDbContext.BankDetails.FirstOrDefault(c => c.MyDev.UserId == id);
    }
}

