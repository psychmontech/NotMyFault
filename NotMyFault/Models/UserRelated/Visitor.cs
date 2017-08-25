using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Visitor
    {
        public Boolean IsAnonumous { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }
}
