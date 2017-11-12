using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.ViewModels
{
    public class ProjWithIfDevIsRated
    {
        public Project Proj { get; set; }
        public bool CurrentDevHasRatedThisDev { get; set; }
    }
}
