﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;

namespace NotMyFault.Models.ProjRelated
{
    public class InterConverEntry
    {
        public int ByDevId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Text { get; set; }
        public string DevNickName { get; set; }
        public virtual Project MyProj { get; set; }
    }
}