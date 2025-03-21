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
        public DbSet<Product> Products { get; set; }
    }
}
