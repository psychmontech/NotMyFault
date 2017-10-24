using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ProjectDevViewModel
    {
        public string ProjName { get; set; }
        public int projId { get; set; }
        public string BriefDescript { get; set; }
        public int Capacity { get; set; }
        public string RepoLink { get; set; }
        public string FullDescript { get; set; }
        public int Progress { get; set; }
        public int Status { get; set; }
        public long Valuation { get; set; }
        public Developer ProjLeader { get; set; }
        public ICollection<Developer> MyDevs { get; set; }
        public DateTime ProtdCompDate { get; set; }
        public DateTime ProjStartingDate { get; set; }
        public bool IsCurrentDevInvolved { get; set; }
    }
}
