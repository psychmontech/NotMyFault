using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface ITransRepo
    {
        Offer FindOfferById(int id);
        ICollection<Offer> GetMyPendingOffersByProjId(int projId);
        ICollection<Offer> GetMyOffersByProjIdBuyerId(int projId, int buyerId);
        Offer GetPendingOfferByProjIdBuyerId(int projId, int buyerId);
        int AddAnOfferToProj(Offer offer, int projId);
        bool ThisBuyerHasPendingOffer(int buyerId, int projId);
        int SaveChanges();
    }
}
