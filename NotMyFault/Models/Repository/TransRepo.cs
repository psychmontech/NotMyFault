using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public class TransRepo : ITransRepo 
    {
        private readonly AppDbContext _appDbContext;

        public TransRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Offer> GetMyOffersByProjId(int id) => _appDbContext.Offers.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);

        public bool ThisBuyerHasOffered(User user, int id) => GetMyOffersByProjId(id).ToList().FindAll(o => o.BuyerId == user.Id).Any();

        public int AddAnOfferToProj(Offer offer, int id)
        {
            _appDbContext.Offers.Add(offer);
            return _appDbContext.SaveChanges();
        }

        public int RemoveAnOffer(int id, int buyerId)
        {
            _appDbContext.Offers.Remove(_appDbContext.Offers.Include(b => b.MyProj).FirstOrDefault(b => b.MyProj.ProjectId == id && b.BuyerId == buyerId));

            return _appDbContext.SaveChanges();
        }

    }
}
