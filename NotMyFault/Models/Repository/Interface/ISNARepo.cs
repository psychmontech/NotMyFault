using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface ISNARepo
    {
        ICollection<SupptNAlleg> GetAllSNA();
        ICollection<SupptNAlleg> GetSNAByUserId(int id);
        ICollection<SNAEntry> GetSNAEntBySNAId(int id);
    }
}
