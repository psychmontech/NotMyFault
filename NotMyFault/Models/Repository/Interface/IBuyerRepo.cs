using NotMyFault.Models.Misce;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IBuyerRepo
    {
        List<Buyer> Buyers { get; }
        Buyer GetBuyerById(int id);
        string GetUsernameById(int id);
        int GetIdByName(string name);
        string GetNickNameById(int id);
        string GetCountryById(int id);
        string GetRegionById(int id);
        byte GetThumbnailById(int id);
        string GetCompNameById(int id);
        string GetCompAddrById(int id);
        int GetEarnestById(int id);
        List<SupptNAlleg> GetMySupNAllegById(int id);
        List<UserProject> GetMyFollowingsById(int id); 
        List<BuyerProject> GetProjsUnderNego(int id);
        List<Negotiation> GetMyNegos(int id);

        void SetUsernameById(int id, string username);
        void SetNickNameById(int id, string nickName);
        void SetCountryById(int id, string country);
        void SetRegionById(int id, string region);
        void SetThumbnailById(int id, byte thumbnail);
        void SetEarnestById(int id, int earnest);
    }
}
