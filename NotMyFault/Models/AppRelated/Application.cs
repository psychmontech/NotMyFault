using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.AppRelated
{
    public class Application
    {
        public IEnumerable<Developer> AllMyDeves { get; set; }
        public IEnumerable<Buyer> AllMyBuyers { get; set; }
        public IEnumerable<Project> AllMyProjs { get; set; }
    }
}
