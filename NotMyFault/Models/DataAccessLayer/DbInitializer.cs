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

            ICollection<UserProject> userproj1 = new List<UserProject> { new UserProject { User = thirdDev }, new UserProject { User = secDev } };
            ICollection<UserProject> userproj2 = new List<UserProject> { new UserProject { User = thirdDev }, new UserProject { User = secDev } };

            Project proj1 = new Project { ProjName = "dummyProj1", BriefDescript = "i am being watched", Initiator = thirdDev, ProjLeader = thirdDev, MyFollowers = userproj1 };
            Project proj2 = new Project { ProjName = "dummyProj2", BriefDescript = "i am being watched as well", Initiator = firstDev, ProjLeader = secDev, MyFollowers = userproj2 };

            //context.Endorsments.AddRange
            //(
            //    new Endorsment { FromDev = firstDev, Subject = "drinking", Timestamp = DateTime.Now, MyDev = thirdDev },
            //    new Endorsment { FromDev = firstDev, Subject = "sleeping", Timestamp = DateTime.Now, MyDev = thirdDev }
            //);

            //Developer firstDev = new Developer { UserName = "Simon Han", NickName = "taekwomon", Country = "China", Region = "Shenyang", Email = "simonoutlook@msn.com", Credit = 10000, LinkedinUrl = "https://www.linkedin.com/in/simon-han-62059baa" };
            //Developer secDev = new Developer { UserName = "Chris Wu", NickName = "yuanyuan", Country = "NZ", Region = "Can", Email = "wyy930@hotmail.com", Credit = 10000 };
            //ICollection<DeveloperProject> devproj1 = new List<DeveloperProject> { new DeveloperProject { Dev = thirdDev }, new DeveloperProject { Dev = secDev } };
            //ICollection<DeveloperProject> devproj2 = new List<DeveloperProject> { new DeveloperProject { Dev = thirdDev }, new DeveloperProject { Dev = secDev } };
            //Project proj1 = new Project { ProjName = "handyApp3", BriefDescript = "this app is handy", Initiator = thirdDev, ProjLeader = thirdDev, MyDevs = devproj1 };
            //Project proj2 = new Project { ProjName = "handyApp4", BriefDescript = "this app is handy", Initiator = firstDev, ProjLeader = secDev, MyDevs = devproj2 };
            context.AddRange
            (
                //firstDev,
                //secDev
                proj1,
                proj2
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
Buybuy.MyWatchingProj = new ICollection<BuyerProject>
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
