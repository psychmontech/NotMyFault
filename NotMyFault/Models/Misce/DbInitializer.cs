using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotMyFault.Models.UserRelated;

namespace NotMyFault.Models.Misce
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Devs.Any())
            {
                context.AddRange
                (
                    new Developer {  UserName = "Simon Han", NickName = "taekwomon", Country = "China", Region = "Shenyang", Age = 28, EmailAddr = "simonoutlook@msn.com", Credit = 10000, LinkedinUrl = "https://www.linkedin.com/in/simon-han-62059baa" },
                    new Developer {  UserName = "Chris Wu", NickName = "yuanyuan", Country = "NZ", Region = "Can", Age = 28, EmailAddr = "wyy930@hotmail.com", Credit = 10000 }
                );
            }

            context.SaveChanges();
        }
    }
}
