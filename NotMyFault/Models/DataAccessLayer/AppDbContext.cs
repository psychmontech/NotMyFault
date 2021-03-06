﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;

namespace NotMyFault.Models.DataAccessLayer
{
    public class AppDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Developer> Devs { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Administrator> Admins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SupptNAlleg> SupptNAllegs{ get; set; }
        public DbSet<SNAEntry> SNAEntries{ get; set; }
        public DbSet<InterConverEntry> InterConverEntries { get; set; }
        public DbSet<CryptcurAddr> CryptcurAddrs { get; set; }
        public DbSet<CryptcurValue> CryptcurValues { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Negotiation> Negotiations { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<PublicOpinion> PublicOpinions { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<TradeBox> TradeBoxes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Endorsment> Endorsments { get; set; }
        public DbSet<NegoEntry> NegoEntries { get; set; }
        public DbSet<Interview> Interviews { get; set; }    
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DeveloperProject> DevProjs{ get; set; }
        public DbSet<DeveloperRecruitment> DevRecruits { get; set; }
        public DbSet<UserProject> UserProjs { get; set; }
        public DbSet<BuyerProject> BuyerProjs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // leader <-> projects 
            modelBuilder.Entity<Project>()
                .HasOne(s => s.ProjLeader)
                .WithMany(c => c.MyLeadingProjs)
                .HasForeignKey("LeaderIdForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            // initiater <-> projects 
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Initiator)
                .WithMany(i => i.MyInitiatedProjs)
                .HasForeignKey("InitiatorIdForeignKey");

            //project <->interconvers
            modelBuilder.Entity<InterConverEntry>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyConver)
                .HasForeignKey("ProjectForeignKey");

            //project <->valuation
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Valuation)
                .WithOne(i => i.MyProj)
                .HasForeignKey<CryptcurValue>("ProjectForeignKey");

            //project <-> distribution
            modelBuilder.Entity<Project>()
                .HasOne(p => p.MyDistribut)
                .WithOne(i => i.MyProj)
                .HasForeignKey<Distribution>("ProjectForeignKey");

            //project <-> transaction
            modelBuilder.Entity<Project>()
                .HasOne(p => p.MyTran)
                .WithOne(i => i.MyProj)
                .HasForeignKey<Transaction>("ProjectForeignKey");

            //transaction <-> tradebox
            modelBuilder.Entity<Transaction>()
                .HasOne(p => p.MyTradeBox)
                .WithOne(i => i.Mytran)
                .HasForeignKey<Transaction>("TransactionForeignKey");

            //developer <-> interviewer
            modelBuilder.Entity<Developer>()
                .HasOne(p => p.MyIntwAsViewer)
                .WithOne(i => i.Interviewer)
                .HasForeignKey<Interview>("DevIntwverForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //developer <-> interviewee
            modelBuilder.Entity<Developer>()
                .HasOne(p => p.MyIntwAsViewee)
                .WithOne(i => i.Interviewee)
                .HasForeignKey<Interview>("DevIntwveeForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //user <-> crypCurAddr
            modelBuilder.Entity<User>()
                .HasOne(p => p.MyCryptcurAddr)
                .WithOne(i => i.MyUser)
                .HasForeignKey<CryptcurAddr>("UserForeignKey");

            //developer <-> endorsgiven
            modelBuilder.Entity<Endorsment>()
                .HasOne(p => p.MyDev)
                .WithMany(i => i.MyEndors)
                .HasForeignKey("EndorsGivenForeignKey");

            //developer <-> endorsgiver
            modelBuilder.Entity<Endorsment>()
                .HasOne(p => p.FromDev)
                .WithMany(i => i.EndorsIGive)
                .HasForeignKey("EndorsGiverForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //developer <-> reviews
            modelBuilder.Entity<Review>()
                .HasOne(p => p.Reviewee)
                .WithMany(i => i.MyReviews)
                .HasForeignKey("RevieweeIdForeignKey");

            //recruitment <-> interviews
            modelBuilder.Entity<Interview>()
                .HasOne(p => p.MyRecruit)
                .WithMany(i => i.MyInterviews)
                .HasForeignKey("RecruitmentForeignKey");

            //negotiation <-> negoEntries
            modelBuilder.Entity<NegoEntry>()
                .HasOne(p => p.MyNego)
                .WithMany(i => i.MyEntries)
                .HasForeignKey("NegoForeignKey");

            //project <-> recruitments
            modelBuilder.Entity<Recruitment>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyRecruits)
                .HasForeignKey("ProjectForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //project <-> offers
            modelBuilder.Entity<Offer>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyOffers)
                .HasForeignKey("ProjectForeignKey");

            //project <-> negotiations
            modelBuilder.Entity<Negotiation>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyNegos)
                .HasForeignKey("ProjectForeignKey");

            //buyer <-> transactions
            modelBuilder.Entity<Transaction>()
                .HasOne(p => p.MyBuyer)
                .WithMany(i => i.AssociateTrans)
                .HasForeignKey("BuyerForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //project <-> publicOpinions
            modelBuilder.Entity<PublicOpinion>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyPubOpin)
                .HasForeignKey("ProjectForeignKey");

            //project <-> likes
            modelBuilder.Entity<Like>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyLikes)
                .HasForeignKey("ProjectForeignKey");

            //user <-> likes
            modelBuilder.Entity<Like>()
                .HasOne(p => p.Liker)
                .WithMany(i => i.ProjILiked)
                .HasForeignKey("UserForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //projects <-> developers
            modelBuilder.Entity<DeveloperProject>()
                .HasOne(dp => dp.Proj)
                .WithMany(d => d.MyDevs)
                .HasForeignKey(dp => dp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DeveloperProject>()
                .HasOne(dp => dp.Dev)
                .WithMany(p => p.MyProjs)
                .HasForeignKey(dp => dp.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //Recruitments <-> developers
            modelBuilder.Entity<DeveloperRecruitment>()
                .HasOne(dp => dp.Recruit)
                .WithMany(d => d.MyCandis)
                .HasForeignKey(dp => dp.RecruitmentId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DeveloperRecruitment>()
                .HasOne(dp => dp.Dev)
                .WithMany(p => p.MyAppliedRoles)
                .HasForeignKey(dp => dp.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //projects <-> users
            modelBuilder.Entity<UserProject>()
                .HasOne(dp => dp.Proj)
                .WithMany(d => d.MyFollowers)
                .HasForeignKey(dp => dp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserProject>()
                .HasOne(dp => dp.User)
                .WithMany(p => p.MyFollowings)
                .HasForeignKey(dp => dp.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //projects <-> buyers
            modelBuilder.Entity<BuyerProject>()
                .HasOne(dp => dp.Proj)
                .WithMany(d => d.MyWatchers)
                .HasForeignKey(dp => dp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<BuyerProject>()
                .HasOne(dp => dp.Buyer)
                .WithMany(p => p.MyWatchingProj)
                .HasForeignKey(dp => dp.Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Foreign Key
            modelBuilder.Entity<Project>().Property<int>("DeveloperForeignKey");
            modelBuilder.Entity<Project>().Property<int>("LeaderIdForeignKey");
            modelBuilder.Entity<Project>().Property<int>("InitiatorIdForeignKey");
            modelBuilder.Entity<InterConverEntry>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<CryptcurValue>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Distribution>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Transaction>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Transaction>().Property<int>("BuyerForeignKey");
            modelBuilder.Entity<Interview>().Property<int>("RecruitmentForeignKey");
            modelBuilder.Entity<Interview>().Property<int>("DevIntwverForeignKey");
            modelBuilder.Entity<Interview>().Property<int>("DevIntwveeForeignKey");
            modelBuilder.Entity<Review>().Property<int>("RevieweeIdForeignKey");
            modelBuilder.Entity<CryptcurAddr>().Property<int>("UserForeignKey");    
            modelBuilder.Entity<Endorsment>().Property<int>("EndorsGivenForeignKey");
            modelBuilder.Entity<Endorsment>().Property<int>("EndorsGiverForeignKey");
            modelBuilder.Entity<NegoEntry>().Property<int>("NegoForeignKey");
            modelBuilder.Entity<Negotiation>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Offer>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<PublicOpinion>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Like>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Like>().Property<int>("UserForeignKey");
            modelBuilder.Entity<TradeBox>().Property<int>("TransactionForeignKey");

            // Configure Primary Key
            modelBuilder.Entity<SNAEntry>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<InterConverEntry>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<Interview>().HasKey(s => s.Time);
            modelBuilder.Entity<Like>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<NegoEntry>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<PublicOpinion>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<Visitor>().HasKey(s => s.NickName);
            modelBuilder.Entity<DeveloperProject>().HasKey(dp => new { dp.Id, dp.ProjectId });
            modelBuilder.Entity<DeveloperRecruitment>().HasKey(dr => new { dr.Id, dr.RecruitmentId});
            modelBuilder.Entity<UserProject>().HasKey(dr => new { dr.Id, dr.ProjectId });
            modelBuilder.Entity<BuyerProject>().HasKey(dr => new { dr.Id, dr.ProjectId });
            modelBuilder.Entity<Transaction>().HasKey(dr => new { dr.TranId});
            modelBuilder.Entity<Review>().HasKey(dr => new { dr.Timestamp});
        }
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
              .SetBasePath(Environment.CurrentDirectory)
              .AddJsonFile("appsettings.json")
              .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
