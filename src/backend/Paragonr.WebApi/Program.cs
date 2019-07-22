using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using Paragonr.Business.Interfaces;
using Paragonr.Persistence;

namespace Paragonr.WebApi
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseNLog()
                .UseStartup<Startup>();
        }

        public static void Main(string[] args)
        {
            IWebHost host;

            // NLog: setup the logger first to catch all errors
            ILogger logger = NLogBuilder.ConfigureNLog("NLog.config")
                .GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                host = CreateWebHostBuilder(args)
                    .Build();
            }
            catch (Exception e)
            {
                //NLog: catch setup errors
                logger.Error(e, "Stopped program because of exception");
                throw;
            }

            using (IServiceScope scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<IBudgetDbContext>();

                    var concreteContext = (BudgetDbContext) context;
                    concreteContext.Database.Migrate();
                    BudgetDbInitializer.Initialize(concreteContext);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "An error occurred while migrating or initializing the database.");
                    throw;
                }
            }

            host.Run();
        }
    }
}