using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;
using NotMyFault.Models.ProjRelated;

namespace NotMyFault.Models.Misce
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            Developer firstDev = context.Devs.Find(1);
            Developer secDev = context.Devs.Find(2);

            Project proj = new Project { ProjName = "smartApp", BriefDescript = "this app is smart", Initiator = firstDev, ProjLeader = secDev };          

            //Developer FirstDev = new Developer { Username = "Simon Han", NickName = "taekwomon", Country = "China", Region = "Shenyang", Age = 28, EmailAddr = "simonoutlook@msn.com", Credit = 10000, LinkedinUrl = "https://www.linkedin.com/in/simon-han-62059baa" };
            //Developer SecDev = new Developer { Username = "Chris Wu", NickName = "yuanyuan", Country = "NZ", Region = "Can", Age = 28, EmailAddr = "wyy930@hotmail.com", Credit = 10000 };
            //if (!context.Projects.Any())
            //{
            //    context.AddRange
            //    (
            //        FirstDev,
            //        SecDev
            //    );
            //}

            context.SaveChanges();
        }
    }
}
