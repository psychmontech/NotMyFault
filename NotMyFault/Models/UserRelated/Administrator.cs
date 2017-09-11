using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public byte Thumbnail { get; set; }
    }
}
