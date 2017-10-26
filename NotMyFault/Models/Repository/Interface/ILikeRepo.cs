using NotMyFault.Models.ProjRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Repository.Interface
{
    public interface ILikeRepo
    {
        ICollection<Like> GetLikesByProjId(int id);
        int AddThisLike(Like like);
    }
}
