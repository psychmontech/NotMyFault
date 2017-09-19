using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository
{
    public interface IProjRepo
    {
        List<Project> Projs { get; }
        Project GetProjById(int id);
        string GetProjnameById(int id);
        string GetBriefDesById(int id);
        string GetFullDesById(int id);
        int GetCapacityById(int id);
        byte GetThumbnailById(int id);
        byte GetGallaryById(int id);
        string GetRepoLinkById(int id);
        decimal GetProgressById(int id);
        DateTime GetStartDateById(int id);
        DateTime GetNxtMeetDateById(int id);    
        DateTime GetProCompDateById(int id);
        List<DeveloperProject> GetMyDevsById(int id);
        Recruitment GetMyRecruitById(int id);
        List<PublicOpinion> GetMyPubOpinById(int id);
        List<Negotiation> GetMyNegosById(int id);
        List<Like> GetMyLikesById(int id);
        List<BuyerProject> GetMyWatchersById(int id);
        List<UserProject> GetMyFollowersById(int id);
        Transaction GetMyTranById(int id);
        Distribution GetMyDistributById(int id);
        Developer GetProjLeaderById(int id);
        Developer GetInitiatorById(int id);
        InternalConver GetMyConverById(int id);

        void SetProjNameById(int id, string projName);
        void SetBriefDesById(int id, string briefDes);
        void SetFullDesById(int id, string fullDes);
        void SetCapacityById(int id, int capacity);
        void SetThumbnailById(int id, byte thumbnail);
        void SetGallaryById(int id, byte gallary);
        void SetRepoLinkById(int id, string repoLink);
        void SetProgressById(int id, decimal progress);
        void SetStartDateById(int id, DateTime startingDate);
        void SetNxtMeetDateById(int id, DateTime meetingDate);
        void SetProCompDateById(int id, DateTime compDate);
    }
}
