using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.Options;
using TechnoStore.Models;

namespace TechnoStore.Data
{
    public class TechnoStoreDbContext : ApiAuthorizationDbContext<User>
    {
        
        public TechnoStoreDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.Order)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);


            builder.Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });


            base.OnModelCreating(builder);
        }
    }
}
