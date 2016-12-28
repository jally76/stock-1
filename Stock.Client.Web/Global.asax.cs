using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using Stock.Core.DataAccess;
using Stock.Core.Migrations;

namespace Stock.Client.Web
{
    public class MvcApplication : HttpApplication
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


          //  MigrateDatabase();
        }

        //TODO move this code to Stock.Core in MigrationService
        private static void MigrateDatabase()
        {
            try
            {
                Logger.Debug("Starting migrate database");
                var databaseContext = DependencyResolver.Current.GetService<EntityFrameworkDataProvider>();

                var connectionString = databaseContext.Database.Connection.ConnectionString;
                if (!Database.Exists(connectionString))
                    throw new Exception($"Database not exist ({connectionString})");

                Database.SetInitializer(new MigrateDatabaseToLatestVersion<EntityFrameworkDataProvider, StockDatabaseConfiguration>());

                var migrator = new DbMigrator(new StockDatabaseConfiguration {CommandTimeout = 0});
                migrator.Update();


                Logger.Debug("Database updated");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);

                //stop application if error
                HttpRuntime.UnloadAppDomain();
                throw;
            }
        }
    }
}
