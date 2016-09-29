using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateDatabase
{
    public class CRMContext : DbContext
    {
        public DbSet<Address> Address { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<StockProduct> StockProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockProduct>()
                .HasKey(x => new { x.StockId, x.ProductId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:crmapi.database.windows.net,1433;Initial Catalog=infnetCRMAPI;Persist Security Info=False;User ID=ramaral;Password=r48xmxdmc44wwW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}