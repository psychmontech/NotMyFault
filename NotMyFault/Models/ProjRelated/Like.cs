using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.ProjRelated
{
    public class Like
    {
        public DateTime Timestamp { get; set; }
        public Project Myproj { get; set; }
        public User Liker { get; set; }
        public Boolean IsVisitor { get; set; }
    }
}
