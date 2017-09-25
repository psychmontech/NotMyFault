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
        public virtual CandiRqrmt MyCandiRqrmts { get; set; }
        public virtual List<DeveloperRecruitment> MyCandis { get; set; }
        public virtual Interview MyInterview { get; set; }
        public string RoleDescription { get; set; }
        public string NameOfTheRole { get; set; }
        public virtual Project MyProj { get; set; }
        public Boolean IsOpen { get; set; }
    }
    public class CandiRqrmt
    {
        public int CandiRqrmtId { get; set; }
        public int Availability { get; set; } // how many other projects that you are working on
        public string Expertise { get; set; } //its a description
        public int MinCredit { get; set; }
        public virtual Recruitment MyRecruit { get; set; }
        public int MaxNumPrjWkOn { get; set; }
    }
    public class Interview
    {
        public DateTime Time { get; set; }
        public virtual Developer Interviewee { get; set; }
        public virtual Developer Interviewer { get; set; }
        public virtual Recruitment MyRecruit { get; set; }
    }
}
