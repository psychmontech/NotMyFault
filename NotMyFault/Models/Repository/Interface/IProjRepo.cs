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
        ICollection<Project> GetProjs(int by, int status, string words);
        Project GetProjById(int id);
        string GetProjnameById(int id);
        string GetBriefDesById(int id);
        string GetFullDesById(int id);
        int GetCapacityById(int id);
        byte GetThumbnailById(int id);
        byte GetGallaryById(int id);
        string GetRepoLinkById(int id);
        int GetProgressById(int id);
        long GetValuationById(int id);
        int GetVisibilityById(int id);
        int GetStatusById(int id);
        DateTime GetStartDateById(int id);
        DateTime GetNxtMeetDateById(int id);    
        DateTime GetProCompDateById(int id);
        ICollection<Developer> GetMyDevsById(int id);
        ICollection<Recruitment> GetMyRecruitsById(int id);
        ICollection<PublicOpinion> GetMyPubOpinById(int id);
        ICollection<Negotiation> GetMyNegosById(int id);
        ICollection<Like> GetMyLikesById(int id);
        ICollection<Buyer> GetMyWatchersById(int id);
        ICollection<User> GetMyFollowersById(int id);
        Transaction GetMyTranById(int id);
        Distribution GetMyDistributById(int id);
        Developer GetProjLeaderById(int id);
        Developer GetInitiatorById(int id);
        ICollection<InternalConver> GetMyConverById(int id);
        bool ThisDevIsInvolved(Developer Dev, int id);
        bool ThisUserHasLiked(Developer dev, int id);
        bool ThisUserHasFollowed(User user, int id);
        int AddProj(Project proj);
        int UpdateProj(Project proj);
        int AddAFollower(User user, int id);
    }
}
