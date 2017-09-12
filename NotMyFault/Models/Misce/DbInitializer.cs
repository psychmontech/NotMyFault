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

            //Developer FirstDev = new Developer { UserName = "Simon Han", NickName = "taekwomon", Country = "China", Region = "Shenyang", Age = 28, EmailAddr = "simonoutlook@msn.com", Credit = 10000, LinkedinUrl = "https://www.linkedin.com/in/simon-han-62059baa" };
            //Developer SecDev = new Developer { UserName = "Chris Wu", NickName = "yuanyuan", Country = "NZ", Region = "Can", Age = 28, EmailAddr = "wyy930@hotmail.com", Credit = 10000 };
            Developer firstDev = context.Devs.Find(2);
            //List<Project> projects = new List<Project>();
            //projects.Add(new Project { ProjName = "smarkApp" });
            //projects.Add(new Project { ProjName = "stupidApp" });

            BankDetails myBank = new BankDetails { AcctName = "simon han", AcctNo = "123-456" };
            firstDev.MyBankDetails = myBank;


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
