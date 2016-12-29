using Stock.Core.DataAccess;

namespace Stock.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class StockDatabaseConfiguration : DbMigrationsConfiguration<EntityFrameworkDataProvider>
    {
        public StockDatabaseConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EntityFrameworkDataProvider context)
        {

        }
    }
}
