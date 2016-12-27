using System;
using System.Collections.Generic;
using System.Data.Entity;
using Stock.Core.Domain;

namespace Stock.Core.EntityFramework
{
    public class StockDatabaseContext : DbContext
    {
        public StockDatabaseContext() : base("name=stock-database") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Tickers)
                .WithMany(t => t.Users)
                .Map(mc =>
                {
                    mc.ToTable("UserTickers");
                    mc.MapLeftKey("UserId");
                    mc.MapRightKey("CompanyId");
                });
        }
    }
}
