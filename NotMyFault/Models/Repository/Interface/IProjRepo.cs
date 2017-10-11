using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IProjRepo
    {
        ICollection<Project> Projs { get; }
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
        ICollection<DeveloperProject> GetMyDevsById(int id);
        ICollection<Recruitment> GetMyRecruitsById(int id);
        ICollection<PublicOpinion> GetMyPubOpinById(int id);
        ICollection<Negotiation> GetMyNegosById(int id);
        ICollection<Like> GetMyLikesById(int id);
        ICollection<BuyerProject> GetMyWatchersById(int id);
        ICollection<UserProject> GetMyFollowersById(int id);
        Transaction GetMyTranById(int id);
        Distribution GetMyDistributById(int id);
        Developer GetProjLeaderById(int id);
        Developer GetInitiatorById(int id);
        ICollection<InternalConver> GetMyConverById(int id);
        int SaveProj(Project proj);
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
