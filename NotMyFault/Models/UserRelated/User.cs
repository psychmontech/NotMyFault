using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.UserRelated
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
    }

    public class Developer : User
    {
        public int Age { get; set; }
        public string EmailAddr { get; set; }
        public string linkedinUrl { get; set; }
    }

    public class Buyer : User
    {
        public string CompanyName { get; set; }
        public string CompanyAddr { get; set; }
    }
}
