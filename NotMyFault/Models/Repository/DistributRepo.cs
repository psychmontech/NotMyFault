using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.Misce;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class DistributRepo : IDistributRepo
    {
        private readonly AppDbContext _appDbContext;

        public DistributRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Distribution GetDistributByProjId (int id) => _appDbContext.Distributions.FirstOrDefault(c => c.MyProj.ProjectId == id);
    }
}
