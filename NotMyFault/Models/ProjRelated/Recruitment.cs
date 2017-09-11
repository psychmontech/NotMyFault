﻿using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Recruitment
    {
        public int RecruitmentId { get; set; }
        public CandiRqrmts MyCandiRqrmts { get; set; }
        public virtual List<DeveloperRecruitment> MyCandis { get; set; }
        public Interview MyInterview { get; set; }
        public string RoleDescription { get; set; }
        public virtual Project MyProj { get; set; }
    }
    public class CandiRqrmts
    {
        public int CandiRqrmtsId { get; set; }
        public int Availability { get; set; } // how many other projects that you are working on
        public string Expertise { get; set; } //its a description
        public virtual int MinCredit { get; set; }
        public virtual Recruitment MyRecruit { get; set; }
    }
    public class Interview
    {
        public DateTime Time { get; set; }
        public Developer Interviewee { get; set; }
        public Developer Interviewer { get; set; }
        public virtual Recruitment MyRecruit { get; set; }
    }
}
