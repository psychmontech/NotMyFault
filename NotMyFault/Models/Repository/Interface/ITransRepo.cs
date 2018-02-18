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
        ICollection<Offer> GetMyOffersByProjId(int projId);
        int AddAnOfferToProj(Offer offer, int projId);
        bool ThisBuyerHasOffered(User user, int projId);
        int RemoveAnOffer(int projId, int buyerId);
    }
}
