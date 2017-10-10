using Microsoft.EntityFrameworkCore;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.Repository.Interface;

namespace NotMyFault.Models.Repository
{
    public class ProjRepo : IProjRepo
    {
        private readonly AppDbContext _appDbContext;

        public ProjRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ICollection<Project> Projs => _appDbContext.Projects.Include(c => c.ProjectId).
            OrderByDescending(x => x.StartingDate).ToList();
        public Project GetProjById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id);
        public string GetProjnameById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProjName;
        public string GetBriefDesById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).BriefDescript;
        public string GetFullDesById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).FullDescript;
        public int GetCapacityById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Capacity;
        public byte GetThumbnailById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Thumbnail;
        public byte GetGallaryById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyGallery;
        public string GetRepoLinkById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).RepoLink;
        public decimal GetProgressById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Progress;
        public DateTime GetStartDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).StartingDate;
        public DateTime GetNxtMeetDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).NextMeetingDate;
        public DateTime GetProCompDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProtdCompDate;
        public ICollection<DeveloperProject> GetMyDevsById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyDevs;
        public ICollection<Recruitment> GetMyRecruitsById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyRecruits;
        public ICollection<PublicOpinion> GetMyPubOpinById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyPubOpin;
        public ICollection<Negotiation> GetMyNegosById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyNegos;
        public ICollection<Like> GetMyLikesById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyLikes;
        public ICollection<BuyerProject> GetMyWatchersById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyWatchers;
        public ICollection<UserProject> GetMyFollowersById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyFollowers;
        public Transaction GetMyTranById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyTran;
        public Distribution GetMyDistributById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyDistribut;
        public Developer GetProjLeaderById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProjLeader;
        public Developer GetInitiatorById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Initiator;
        public ICollection<InternalConver> GetMyConverById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyConver;

        public void SetProjNameById(int id, string projName)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProjName = projName;
            _appDbContext.SaveChanges();
        }

        public void SetBriefDesById(int id, string briefDes)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).BriefDescript = briefDes;

        }

        public void SetFullDesById(int id, string fullDes)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).FullDescript = fullDes;
            _appDbContext.SaveChanges();
        }

        public void SetCapacityById(int id, int capacity)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Capacity = capacity;
            _appDbContext.SaveChanges();
        }

        public void SetThumbnailById(int id, byte thumbnail)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Thumbnail = thumbnail;
            _appDbContext.SaveChanges();
        }

        public void SetGallaryById(int id, byte gallary)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyGallery = gallary;
            _appDbContext.SaveChanges();
        }

        public void SetRepoLinkById(int id, string repoLink)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).RepoLink = repoLink;
            _appDbContext.SaveChanges();
        }

        public void SetProgressById(int id, decimal progress)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Progress = progress;
            _appDbContext.SaveChanges();
        }

        public void SetStartDateById(int id, DateTime startingDate)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).StartingDate = startingDate;
            _appDbContext.SaveChanges();
        }

        public void SetNxtMeetDateById(int id, DateTime meetingDate)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).NextMeetingDate = meetingDate;
            _appDbContext.SaveChanges();
        }

        public void SetProCompDateById(int id, DateTime compDate)
        {
            _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProtdCompDate = compDate;
            _appDbContext.SaveChanges();
        }
    }
}
