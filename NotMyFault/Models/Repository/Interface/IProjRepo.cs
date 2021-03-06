﻿using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static NotMyFault.Models.ProjRelated.Project;

namespace NotMyFault.Models.Repository.Interface
{
    public interface IProjRepo
    {
        ICollection<Project> GetProjs(int by, int status, string words);
        Project GetProjById(int id);
        string GetProjnameById(int id);
        string GetMissStateById(int id);
        string GetFullDesById(int id);
        int GetCapacityById(int id);
        byte GetThumbnailById(int id);
        byte GetGallaryById(int id);
        string GetRepoLinkById(int id);
        int GetProgressById(int id);
        int GetVisibilityById(int id);
        int GetStatusById(int id);
        Nullable<DateTime> GetStartDateById(int id);
        Nullable<DateTime> GetNxtMeetDateById(int id);
        Nullable<DateTime> GetProCompDateById(int id);
        CryptcurValue GetValuationById(int id);
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
        ICollection<InterConverEntry> GetMyConverById(int id);
        bool ThisDevIsInvolved(User user, int id);
        bool ThisUserHasLiked(User user, int id);
        bool ThisUserHasFollowed(User user, int id);
        bool ThisBuyerHasWatched(User user, int id);
        bool HasOpenRecruits(int id);
        bool HasAnyNegosToLookat(int id);
        int AddProj(Project proj);
        int SaveChanges();
        int AddAFollower(User user, int id);
        int RemoveAFollower(User user, int id);
        int AddAWatcher(Buyer buyer, int id);
        int RemoveAWatcher(Buyer buyer, int id);
        int AddADev(int id, Developer dev);
        int DismissADev(int id, int devId);
        Nullable<DateTime> GetCompleteDateById(int id);
        Nullable<DateTime> GetAbortDateById(int id);
    }
}
