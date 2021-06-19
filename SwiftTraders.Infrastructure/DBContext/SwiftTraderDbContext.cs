using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwiftTraders.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwiftTraders.Infrastructure.DBContext
{
    public class SwiftTraderDbContext : IdentityDbContext<Users>
    {
        public SwiftTraderDbContext(DbContextOptions<SwiftTraderDbContext> options) : base(options) { }

        public DbSet<Users> User { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AdvertModel> AdvertModels { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
