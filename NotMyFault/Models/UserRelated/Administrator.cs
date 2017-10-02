using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public byte Thumbnail { get; set; }
    }
}
