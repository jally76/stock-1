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
           
        }
    }
}
