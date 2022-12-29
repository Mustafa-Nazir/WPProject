using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class WPProjectDbContext:IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=WPProjectDb;Trusted_Connection=true");
        }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Emoji> Emojis { get; set; }
        public DbSet<Follower> Followeres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageDetail> ImageDetails { get; set; }
    }
}
