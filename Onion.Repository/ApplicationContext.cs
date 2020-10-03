using Microsoft.EntityFrameworkCore;
using Onion.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
            new ProductDetailMap(modelBuilder.Entity<ProductDetails>());
        }
        public DbSet<Onion.DataAccess.Product> Product { get; set; }
    }
}
