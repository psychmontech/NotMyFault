using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface ISNARepo
    {
        List<SupptNAlleg> GetAllSNA();
        List<SupptNAlleg> GetSNAByUserId(int id);
        List<SNAEntry> GetSNAEntBySNAId(int id);
    }
}
