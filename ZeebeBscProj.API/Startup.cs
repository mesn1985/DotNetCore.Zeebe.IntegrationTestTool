using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZeebeBscProj.Repositories.Contracts;
using ZeebeBscProj.Repositories.Implementations.ZBClient;
using ZeebeBscProj.Repositories.Implementations.ZeebeElasticScearch;

namespace ZeebeBscProj.API
{

    public class Startup
    {
        public IWebHostEnvironment env { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddTransient<IWorkflowRepo>(
                provider =>ZeebeRepositoryFactory.GetWorkFlowRepo(Configuration.GetConnectionString("ZeebeGateway")));
            services.AddTransient<ITopologyRepo>(
                provider => ZeebeRepositoryFactory.GetTopologyRepo(Configuration.GetConnectionString("ZeebeGateway")));
            services.AddSingleton<IWorkerRepo>(
                provider => ZeebeRepositoryFactory.GetWorkerRepo(Configuration.GetConnectionString("ZeebeGateway")));
            services.AddTransient<IElasticSearchZeebeRepo>(
                provider => ZeebeElasticSearchRepoFactory.GetZeebeElasticSearchRepo(Configuration.GetConnectionString("ElasticSearch")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
                             {
                                 endpoints.MapControllerRoute(
                                     "default",
                                     "{controller=Home}/{action=Index}/{id?}");
                             });
        }
    }

}