﻿using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Like
    {
        public DateTime Timestamp { get; set; }
        public virtual Project MyProj { get; set; }
        public virtual User Liker { get; set; }
        public Boolean IsVisitor { get; set; }
    }
}
