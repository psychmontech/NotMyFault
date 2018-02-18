using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotMyFault.Models.DataAccessLayer;
using NotMyFault.Models.Repository.Interface;
using NotMyFault.Models.Repository;
using NotMyFault.Models.UserRelated;
using NotMyFault.Hubs;

namespace NotMyFault
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
                             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<User, ApplicationRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<IBuyerRepo, BuyerRepo>();
            services.AddTransient<IDevRepo, DevRepo>();
            services.AddTransient<IEndorsRepo, EndorsRepo>();
            services.AddTransient<IInterConverRepo, InterConverRepo>();
            services.AddTransient<ILikeRepo, LikeRepo>();
            services.AddTransient<INegoRepo, NegoRepo>();
            services.AddTransient<IProjRepo, ProjRepo>();
            services.AddTransient<IReviewRepo, ReviewRepo>();
            services.AddTransient<ITransRepo, TransRepo>();
            services.AddTransient<IRecruitRepo, RecruitRepo>();
            services.AddTransient<ISNARepo, SNARepo>();
            services.AddTransient<IPubOpinRepo, PubOpinRepo>();
            services.AddMvc();
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<DevsHub>("devsHub");
                routes.MapHub<NegoHub>("negoHub");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Account}/{action=Start}/{id?}");
        });

            //DbInitializer.Seed(app);
        }
    }
}
