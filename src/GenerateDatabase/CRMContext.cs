using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerateDatabase
{
    public class CRMContext : DbContext
    {
        public DbSet<Adress> Adress { get; set; }
        public DbSet<Company> Company { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Product> Product { get; set; }
        public DbSet<Stock> Stock { get; set; }

        public DbSet<StockProduct> StockProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockProduct>()
                .HasKey(c => new { c.ProductId, c.StockId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MACBOOKPRO\SQLEXPRESS;Database=CRMAPI;User Id=sa;Password=r48xmxdmc44w;");
        }
    }
}