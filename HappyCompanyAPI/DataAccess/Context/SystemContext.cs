using DataAccess.Entities;
using DataAccess.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SystemContext:IdentityDbContext<ApplicationUser>
    {
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {

        }
        public DbSet<Warehouse> warehouses { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Country> countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Warehouse>().HasIndex(w => w.Name).IsUnique();
            builder.Entity<Item>().HasIndex(i => i.Name).IsUnique();
        }
    }
    
}
