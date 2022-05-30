using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Syncfusion.Blazor;
using System.Linq;
using System.Threading.Tasks;
using TransactionWeb.Entities;
using TransactionWeb.Repos;
using TransactionWeb.Services;
using MatBlazor;
using Syncfusion.Licensing;

namespace TransactionWeb
{
    public class Startup
    {
        string DatabaseConnectionString { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DatabaseConnectionString = Environment.GetEnvironmentVariable($"CONN_TransactionTestDB");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 65536;
            });

            #region Data Access Layer
            //DBContext
            services.AddDbContext<DBContext>(options => options.UseSqlServer(DatabaseConnectionString), ServiceLifetime.Scoped);

            //Repositories
            services.AddScoped<IRepository<Transactions>, TransactionRepo>();

            #endregion

            #region Service Layer            
            services.AddScoped<ITransactionService, TransactionService>();
            #endregion

            #region 3rd Party Package & Componenet
            services.AddSyncfusionBlazor();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 100;
                config.VisibleStateDuration = 3000;
                config.ShowTransitionDuration = 200;
                config.HideTransitionDuration = 500;
            });
            #endregion

            #region ASP.NET Core
            //ASP.NET Core SignalR Buffer management
            services.AddSignalR(e => { e.MaximumReceiveMessageSize = 10240000000; });
            services.AddRazorPages();
            services.AddMemoryCache();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            #region 3rd Party Packages
            SyncfusionLicenseProvider.RegisterLicense("Mzg5NTU4QDMxMzgyZTM0MmUzMGpVSjJrS3ZVMHc5THVVQW5qZ1djVDNtMkxWSXBLT3hmYXRidWpEdzNWVkE9");
            #endregion

            #region ASP.NET Core
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}");

                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            #endregion
        }

    }
}
