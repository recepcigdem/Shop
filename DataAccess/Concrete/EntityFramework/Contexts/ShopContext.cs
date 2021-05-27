using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RM12FDR;Database=Shop;Trusted_Connection=true");
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> User { get; set; }
    }
}
