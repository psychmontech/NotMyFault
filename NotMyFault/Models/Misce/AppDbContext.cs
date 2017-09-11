using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using NotMyFault.Models.ProjRelated;
using NotMyFault.Models.TransRelated;
using NotMyFault.Models.UserRelated;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotMyFault.Models.Misce
{
    public class AppDbContext : DbContext
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
        public DbSet<InternalConver> InternalConver { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

            //project <->conversation
            modelBuilder.Entity<Project>()
                .HasOne(p => p.MyConver)
                .WithOne(i => i.MyProj)
                .HasForeignKey<InternalConver>("ProjectForeignKey");

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

            //project <-> recruitment
            modelBuilder.Entity<Project>()
                .HasOne(p => p.MyRecruit)
                .WithOne(i => i.MyProj)
                .HasForeignKey<Recruitment>("ProjectForeignKey");

            //recruitment <-> candidateRequirement
            modelBuilder.Entity<Recruitment>()
                .HasOne(p => p.MyCandiRqrmts)
                .WithOne(i => i.MyRecruit)
                .HasForeignKey<Recruitment>("RecruitmentForeignKey");

            //recruitment <-> interview
            modelBuilder.Entity<Recruitment>()
                .HasOne(p => p.MyInterview)
                .WithOne(i => i.MyRecruit)
                .HasForeignKey<Interview>("RecruitmentForeignKey");

            //developer <-> bankdetails
            modelBuilder.Entity<Developer>()
                .HasOne(p => p.MyBankDetails)
                .WithOne(i => i.MyDev)
                .HasForeignKey<BankDetails>("DeveloperForeignKey");

            //developer <-> reviews
            modelBuilder.Entity<Review>()
                .HasOne(p => p.MyReviewee)
                .WithMany(i => i.MyReviews)
                .HasForeignKey("RevieweeIdForeignKey");

            //developer <-> revieweds
            modelBuilder.Entity<Review>()
                .HasOne(p => p.MyReviewer)
                .WithMany(i => i.MyReviewed)
                .HasForeignKey("ReviewerIdForeignKey")
                .OnDelete(DeleteBehavior.Restrict);

            //negotiation <-> negoEntries
            modelBuilder.Entity<NegoEntry>()
                .HasOne(p => p.MyNego)
                .WithMany(i => i.MyEntries)
                .HasForeignKey("NegoForeignKey");

            //project <-> negotiations
            modelBuilder.Entity<Negotiation>()
                .HasOne(p => p.MyProj)
                .WithMany(i => i.MyNegos)
                .HasForeignKey("ProjectForeignKey");

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

            //projects <-> developers
            modelBuilder.Entity<DeveloperProject>()
                .HasOne(dp => dp.Proj)
                .WithMany(d => d.MyDevs)
                .HasForeignKey(dp => dp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DeveloperProject>()
                .HasOne(dp => dp.Dev)
                .WithMany(p => p.MyProjs)
                .HasForeignKey(dp => dp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Recruitments <-> developers
            modelBuilder.Entity<DeveloperRecruitment>()
                .HasOne(dp => dp.Recruit)
                .WithMany(d => d.MyCandis)
                .HasForeignKey(dp => dp.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<DeveloperRecruitment>()
                .HasOne(dp => dp.Dev)
                .WithMany(p => p.MyAppliedRoles)
                .HasForeignKey(dp => dp.RecruitmentId)
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
                .HasForeignKey(dp => dp.UserId)
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
                .HasForeignKey(dp => dp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Foreign Key
            modelBuilder.Entity<Project>().Property<int>("DeveloperForeignKey");
            modelBuilder.Entity<Project>().Property<int>("LeaderIdForeignKey");
            modelBuilder.Entity<Project>().Property<int>("InitiatorIdForeignKey");
            modelBuilder.Entity<InternalConver>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Distribution>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Transaction>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<CandiRqrmts>().Property<int>("RecruitmentForeignKey");
            modelBuilder.Entity<Interview>().Property<int>("RecruitmentForeignKey");
            modelBuilder.Entity<Review>().Property<int>("RevieweeIdForeignKey");
            modelBuilder.Entity<Review>().Property<int>("ReviewerIdForeignKey");
            modelBuilder.Entity<BankDetails>().Property<int>("DeveloperForeignKey");
            modelBuilder.Entity<NegoEntry>().Property<DateTime>("NegoForeignKey");
            modelBuilder.Entity<Negotiation>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<PublicOpinion>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<Like>().Property<int>("ProjectForeignKey");
            modelBuilder.Entity<TradeBox>().Property<int>("TransactionForeignKey");

            // Configure Primary Key
            modelBuilder.Entity<SNAEntry>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<InternalConver>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<Interview>().HasKey(s => s.Time);
            modelBuilder.Entity<Like>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<NegoEntry>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<Negotiation>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<PublicOpinion>().HasKey(s => s.Timestamp);
            modelBuilder.Entity<Visitor>().HasKey(s => s.NickName);
            modelBuilder.Entity<DeveloperProject>().HasKey(dp => new { dp.UserId, dp.ProjectId });
            modelBuilder.Entity<DeveloperRecruitment>().HasKey(dr => new { dr.UserId, dr.RecruitmentId});
            modelBuilder.Entity<UserProject>().HasKey(dr => new { dr.UserId, dr.ProjectId });
            modelBuilder.Entity<BuyerProject>().HasKey(dr => new { dr.UserId, dr.ProjectId });
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
