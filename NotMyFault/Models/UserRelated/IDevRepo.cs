using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public interface IDevRepo
    {
        List<Developer> Devs { get; }
        Developer GetDevById(int DevId);
    }
}
