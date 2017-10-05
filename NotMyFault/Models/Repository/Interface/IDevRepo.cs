﻿using NotMyFault.Models.DataAccessLayer;
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
        List<Developer> Devs { get; }
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
        List<SupptNAlleg> GetMySupNAllegById(int id);
        List<UserProject> GetMyFollowingsById(int id);
        List<Endorsment> GetEndorsById(int id);
        List<DeveloperProject> GetMyProjsById(int id);
        List<Project> GetMyLeadingProjsById(int id);
        List<DeveloperRecruitment> GetMyAppliedRolesById(int id);
        List<Review> GetMyReviewsById(int id);
        string GetSelfIntroById(int id);
        BankDetails GetMyBankDetailsById(int id);

        void SetLinkedinById(int id, string linkedinUrl);
        void SetNumProjWrkOnById(int id, int age);
        void SetUsernameById(int id, string username);
        void SetNickNameById(int id, string nickName);
        void SetCountryById(int id, string country);
        void SetRegionById(int id, string region);
        void SetThumbnailById(int id, byte thumbnail);
        void SetSelfIntroById(int id, string skills);
    }
}