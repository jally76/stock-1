using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Stock.Core.EntityFramework;

namespace Stock.Core.Services
{
    public class MigrationService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void MigrateToLastVersion(string nameOrConnectionString)
        {
            //запускаем миграции базы данных при старте приложения
            try
            {
                //Logger.Debug("Начинаем обновлять базу данных");
                //var databaseContext = new StockDatabaseContext(nameOrConnectionString);

                //var connectionString = databaseContext.Database.Connection.ConnectionString;
                //if (!Database.Exists(connectionString))
                //    throw new Exception($"База данных не найдена. Строка подключения: {connectionString}");

                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StockDatabaseContext, >());

                //var migrator = new DbMigrator();
                //migrator.Update();

                //DatabaseMigrator<StockDatabaseContext, Configuration>.MigrateToLastVersion(databaseContext);
                //Logger.Debug("База данных обновлена ");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex);

                //останавливаем приложение в случае ошибок миграции
                //HttpRuntime.UnloadAppDomain();
                throw;
            }
        }
    }
}
