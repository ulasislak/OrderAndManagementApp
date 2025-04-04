using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class OrderAndManagmentDbContext:DbContext
    {
        public OrderAndManagmentDbContext(DbContextOptions<OrderAndManagmentDbContext> options) : base(options)
        {

        }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Çokaçok ilişkiyi tanımlıyoruz
            modelBuilder.Entity<CustomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });

            modelBuilder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Costumers)
                .WithMany(c => c.CustomerProducts)
                .HasForeignKey(cp => cp.CustomerId);

            modelBuilder.Entity<CustomerProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CustomerProducts)
                .HasForeignKey(cp => cp.ProductId);
        }
    }
}
