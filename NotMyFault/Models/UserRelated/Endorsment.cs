﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Endorsment
    {
        public Developer MyDev { get; set; }
        public Developer FromDev { get; set; }
        public string subject { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
    