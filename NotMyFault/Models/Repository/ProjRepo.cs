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
using NotMyFault.Constants;

namespace NotMyFault.Models.Repository
{
    public class ProjRepo : IProjRepo
    {
        private readonly AppDbContext _appDbContext;

        public ProjRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<Project> GetProjs(int by, int status, string words)
        {
            List<int> st = new List<int>();
            switch (status)
            {
                case  ProjSearchCriteria.CompletedOnly:
                    st.Add(ProjStatus.Completed);
                    break;

                case ProjSearchCriteria.All:
                    st.Add(ProjStatus.Completed);
                    st.Add(ProjStatus.Preparing);
                    st.Add(ProjStatus.Recruiting);
                    st.Add(ProjStatus.Under_Development);
                    st.Add(ProjStatus.Under_Negotiation);
                    st.Add(ProjStatus.Transaction_Processing);
                    break;

                case ProjSearchCriteria.OpenInclSusp:
                    st.Add(ProjStatus.Preparing);
                    st.Add(ProjStatus.Recruiting);
                    st.Add(ProjStatus.Under_Development);
                    st.Add(ProjStatus.Under_Negotiation);
                    st.Add(ProjStatus.Transaction_Processing);
                    st.Add(ProjStatus.Suspended);
                    break;

                case ProjSearchCriteria.AllInclSusp:
                    st.Add(ProjStatus.Completed);
                    st.Add(ProjStatus.Preparing);
                    st.Add(ProjStatus.Recruiting);
                    st.Add(ProjStatus.Under_Development);
                    st.Add(ProjStatus.Under_Negotiation);
                    st.Add(ProjStatus.Transaction_Processing);
                    st.Add(ProjStatus.Suspended);
                    break;

                default:
                    st.Add(ProjStatus.Preparing);
                    st.Add(ProjStatus.Recruiting);
                    st.Add(ProjStatus.Under_Development);
                    st.Add(ProjStatus.Under_Negotiation);
                    st.Add(ProjStatus.Transaction_Processing);
                    break;
            }
            switch (by)
            {
                case ProjSearchCriteria.ByPopularity:
                    return _appDbContext.Projects.Where(x => st.Contains(x.Status) && (words == null || (x.ProjName.Contains(words) 
                        || x.BriefDescript.Contains(words) || x.FullDescript.Contains(words)))).OrderByDescending(x => x.MyLikes.Count).ToList();

                case ProjSearchCriteria.ByProgress:
                    return _appDbContext.Projects.Where(x => st.Contains(x.Status) && (words == null || (x.ProjName.Contains(words) 
                        || x.BriefDescript.Contains(words) || x.FullDescript.Contains(words)))).OrderByDescending(x => x.Progress).ToList();

                case ProjSearchCriteria.ByValuation:
                    return _appDbContext.Projects.Where(x => st.Contains(x.Status) && (words == null || (x.ProjName.Contains(words) 
                        || x.BriefDescript.Contains(words) || x.FullDescript.Contains(words)))).OrderByDescending(x => x.Valuation).ToList();

                default:
                    return _appDbContext.Projects.Where(x => st.Contains(x.Status) && (words == null || (x.ProjName.Contains(words) 
                        || x.BriefDescript.Contains(words) || x.FullDescript.Contains(words)))).OrderByDescending(x => x.StartingDate).ToList();
            }
        }

        public Project GetProjById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id);
        public string GetProjnameById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProjName;
        public string GetBriefDesById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).BriefDescript;
        public string GetFullDesById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).FullDescript;
        public int GetCapacityById(int id) => _appDbContext.DevProjs.Include(d => d.Dev).Where(p => p.ProjectId == id).ToList().Count;
        public byte GetThumbnailById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Thumbnail;
        public byte GetGallaryById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).MyGallery;
        public string GetRepoLinkById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).RepoLink;
        public int GetProgressById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Progress;
        public int GetStatusById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Status;
        public int GetVisibilityById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Visibility;
        public long GetValuationById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).Valuation;
        public DateTime GetStartDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).StartingDate;
        public DateTime GetNxtMeetDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).NextMeetingDate;
        public DateTime GetProCompDateById(int id) => _appDbContext.Projects.FirstOrDefault(p => p.ProjectId == id).ProtdCompDate;
        public ICollection<Developer> GetMyDevsById(int id) => _appDbContext.DevProjs.Where(p => p.ProjectId == id).Select(d => d.Dev).ToList(); //look at me
        public ICollection<Recruitment> GetMyRecruitsById(int id) => _appDbContext.Recruitments.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);
        public ICollection<PublicOpinion> GetMyPubOpinById(int id) => _appDbContext.PublicOpinions.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id); //look at me
        public ICollection<Negotiation> GetMyNegosById(int id) => _appDbContext.Negotiations.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);
        public ICollection<Like> GetMyLikesById(int id) => _appDbContext.Likes.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);
        public ICollection<Buyer> GetMyWatchersById(int id) => _appDbContext.BuyerProjs.Where(p => p.ProjectId == id).Select(d => d.Buyer).ToList(); 
        public ICollection<User> GetMyFollowersById(int id) => _appDbContext.UserProjs.Where(p => p.ProjectId == id).Select(d => d.User).ToList(); 
        public Transaction GetMyTranById(int id) => _appDbContext.Transactions.Include(p => p.MyProj).ToList().FirstOrDefault(c => c.MyProj.ProjectId == id);
        public Distribution GetMyDistributById(int id) => _appDbContext.Distributions.Include(p => p.MyProj).ToList().FirstOrDefault(c => c.MyProj.ProjectId == id);
        public Developer GetProjLeaderById(int id) => _appDbContext.Devs.Include(d => d.MyLeadingProjs).FirstOrDefault(d => d.MyLeadingProjs.Any(p => p.ProjectId == id));  //look at me
        public Developer GetInitiatorById(int id) => _appDbContext.Devs.Include(d => d.MyInitiatedProjs).FirstOrDefault(d => d.MyInitiatedProjs.Any(p => p.ProjectId == id));
        public ICollection<InternalConver> GetMyConverById(int id) => _appDbContext.InternalConver.Include(p => p.MyProj).ToList().FindAll(c => c.MyProj.ProjectId == id);
        public bool ThisDevIsInvolved(User user, int id) => GetMyDevsById(id).Contains((Developer)user);
        public bool ThisUserHasLiked(User user, int id) => _appDbContext.Likes.Include(l => l.MyProj).Include(l => l.Liker).ToList().
                                                               FindAll(l => l.MyProj.ProjectId == id).FirstOrDefault(l => l.Liker == user) != null;
        public bool ThisUserHasFollowed(User user, int id) => GetMyFollowersById(id).Contains(user);
        public bool ThisBuyerHasWatched(User user, int id) => GetMyWatchersById(id).Contains((Buyer)user);
        public bool HasOpenRecruits(int id) => _appDbContext.Recruitments.Include(p => p.MyProj).ToList().FindAll(r => r.MyProj.ProjectId == id && r.IsOpen == true).Any();
        public int AddProj(Project proj)
        {
            _appDbContext.Projects.Add(proj);
            return _appDbContext.SaveChanges();
        }

        public int SaveChanges() => _appDbContext.SaveChanges();

        public int AddAFollower(User user, int id)
        {
            _appDbContext.UserProjs.Add(
                new UserProject
                {
                    Proj = GetProjById(id),
                    User = user
                });
            return _appDbContext.SaveChanges();
        }

        public int AddAWatcher(Buyer buyer, int id)
        {
            _appDbContext.BuyerProjs.Add(
                new BuyerProject
                {
                    Proj = GetProjById(id),
                    Buyer = buyer
                });
            return _appDbContext.SaveChanges();
        }

        public int AddADev(int id, Developer dev)
        {
            _appDbContext.DevProjs.Add(
                new DeveloperProject
                {
                    Proj = GetProjById(id),
                    Dev = dev
                });
            return _appDbContext.SaveChanges();
        }
    }
}
