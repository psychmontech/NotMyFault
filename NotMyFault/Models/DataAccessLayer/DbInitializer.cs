using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;

namespace NotMyFault.Models.DataAccessLayer
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            Developer firstDev = context.Devs.Find(1);
            Developer secDev = context.Devs.Find(2);
            Developer thirdDev = context.Devs.Find(3);
            //Project proj = context.Projects.Find(1);

            //context.Devs.Add(new Developer
            //{
            //    UserName = "wawa",
            //    NickName = "wawawa",
            //    MyLeadingProjs = new List<Project>
            //    {
            //        new Project
            //        {
            //            ProjName = "wawaproject1",
            //            BriefDescript = "this is wawa project1",
            //            ProjLeader = firstDev,
            //            Initiator = firstDev
            //        },
            //        new Project
            //        {
            //            ProjName = "wawaproject2",
            //            BriefDescript = "this is wawa project2",
            //            ProjLeader = firstDev,
            //            Initiator = firstDev
            //        }
            //    }
            //});
            //Developer firstDev = new Developer { UserName = "Simon Han", NickName = "taekwomon", Country = "China", Region = "Shenyang", Email = "simonoutlook@msn.com", Credit = 10000, LinkedinUrl = "https://www.linkedin.com/in/simon-han-62059baa" };
            //Developer secDev = new Developer { UserName = "Chris Wu", NickName = "yuanyuan", Country = "NZ", Region = "Can", Email = "wyy930@hotmail.com", Credit = 10000 };
            List<DeveloperProject> devproj = new List<DeveloperProject> { new DeveloperProject { Dev = thirdDev }, new DeveloperProject { Dev = secDev } };
            Project proj1 = new Project { ProjName = "handyApp3", BriefDescript = "this app is handy", Initiator = thirdDev, ProjLeader = thirdDev, MyDevs = devproj };
            //Project proj2 = new Project { ProjName = "handyApp4", BriefDescript = "this app is handy", Initiator = firstDev, ProjLeader = secDev };
            context.AddRange
            (
                //firstDev,
                //secDev
                proj1
                //proj2
            );

            context.SaveChanges();
        }
    }
}



/*//one to one
Developer secDev = context.Devs.Find(2);
BankDetails bankDetails = new BankDetails { AcctName = "simon h", AcctNo = "123-456" };
secDev.MyBankDetails = bankDetails;
---------------
Developer firstDev = context.Devs.Find(1);
BankDetails bankDetails = new BankDetails { AcctName = "chris w", AcctNo = "123-456", MyDev = firstDev };
context.BankDetails.Add(bankDetails);*/

/*//one to many
Project proj = context.Projects.Find(1);
Like like = new Like { Timestamp = DateTime.Now, MyProj = proj };
context.Likes.Add(like); --> works
----------------
Project proj = context.Projects.Find(1);
Like like = new Like { Timestamp = DateTime.Now };
proj.MyLikes.Add(like);   --> doesn't work*/

/*//many to many
Developer firstDev = context.Devs.Find(1);
Developer secDev = context.Devs.Find(2);
Project proj = new Project { ProjName = "handyApp", BriefDescript = "this app is handy", Initiator = firstDev, ProjLeader = secDev };
Buyer Buybuy = new Buyer { UserName = "Rob L", NickName = "Bert", Country = "NZ", Region = "AUK", CompanyName = "Taitee" };
Buybuy.ProjsUnderNego = new List<BuyerProject>
{
    new BuyerProject {
    Buyer = Buybuy,
    Proj = proj,
    }
};
context.Buyers.Add(Buybuy);*/


/*//remove all the objects            
foreach (var entity in context.Projects)
context.Projects.Remove(entity);*/
