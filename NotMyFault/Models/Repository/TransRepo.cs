using Microsoft.EntityFrameworkCore;
using NotMyFault.Constants;
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

        public Offer FindOfferById(int id) => _appDbContext.Offers.FirstOrDefault(o => o.OfferId== id);

        public ICollection<Offer> GetMyPendingOffersByProjId(int id) => _appDbContext.Offers.Include(p => p.MyProj).ToList()
                                                            .FindAll(c => c.MyProj.ProjectId == id && c.Status == OfferStatus.Pending);

        public ICollection<Offer> GetMyOffersByProjIdBuyerId(int projId, int buyerId) => _appDbContext.Offers.Include(p => p.MyProj).OrderByDescending(o => o.OfferId).ToList()
                                                    .FindAll(c => c.MyProj.ProjectId == projId && c.BuyerId == buyerId);

        public Offer GetPendingOfferByProjIdBuyerId(int projId, int buyerId) => _appDbContext.Offers.Include(p => p.MyProj).ToList()
                                                    .FirstOrDefault(o => o.MyProj.ProjectId == projId && o.BuyerId == buyerId && o.Status == OfferStatus.Pending);
        public bool ThisBuyerHasPendingOffer(int buyerId, int projId) => GetMyPendingOffersByProjId(projId).ToList().FindAll(o => o.BuyerId == buyerId).Any();

        public int AddAnOfferToProj(Offer offer, int id)
        {
            _appDbContext.Offers.Add(offer);
            return _appDbContext.SaveChanges();
        }

        public int SaveChanges() => _appDbContext.SaveChanges();

    }
}
