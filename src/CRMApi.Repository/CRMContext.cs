using CRMApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApi.Repository
{
    public class CRMContext : DbContext
    {
        public DbSet<Address> Address { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Stock> Stock { get; set; }

        public DbSet<StockProduct> StockProdcut { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockProduct>()
                .HasKey(x => new { x.StockId, x.ProductId });

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MACBOOKPRO\SQLEXPRESS;Database=CRMAPI;User Id=sa;Password=r48xmxdmc44w;");
        }
    }
}