using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Recruitment
    {
        public int RecruitmentId { get; set; }
        public virtual ICollection<DeveloperRecruitment> MyCandis { get; set; }
        public virtual ICollection<Interview> MyInterviews { get; set; }
        public string RoleDescription { get; set; }
        public string NameOfTheRole { get; set; }
        public virtual Project MyProj { get; set; }
        public Boolean IsOpen { get; set; }
        public string RequirDescript { get; set; } //its a description
        public int MinCredit { get; set; }
        public int MaxNumPrjWkOn { get; set; } // how many other projects that you are working on
        public DateTime DateCreated { get; set; }
    }
    public class Interview
    {
        public DateTime Time { get; set; }
        public virtual Developer Interviewee { get; set; }
        public virtual Developer Interviewer { get; set; }
        public virtual Recruitment MyRecruit { get; set; }
    }
}
