using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IDevRepo
    {
        ICollection<Developer> Devs { get; }
        Developer GetDevById(int id);
        string GetUsernameById(int id);
        int GetIdByName(string name);
        string GetNickNameById(int id);
        int GetRoleById(int id);
        string GetCountryById(int id);
        string GetRegionById(int id);
        int GetNumProjWrkOnById(int id);
        string GetEmailById(int id);
        string GetLinkedinById(int id);
        int GetCreditById(int id);
        ICollection<SupptNAlleg> GetMySupNAllegById(int id);
        ICollection<Project> GetMyFollowingsById(int id);
        ICollection<Endorsment> GetEndorsById(int id);
        ICollection<Project> GetMyProjsById(int id);
        ICollection<Project> GetMyCompletedProjsById(int id);
        ICollection<Project> GetMyLeadingProjsById(int id);
        ICollection<Recruitment> GetMyAppliedRolesById(int id);
        ICollection<Review> GetMyReviewsById(int id);
        string GetSelfIntroById(int id);
        CrypCurAddr GetCrypCurAddrById(int id);
    }
}
