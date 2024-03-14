using EMart.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TeamType> TeamTypes { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamType>().HasData(
                  new TeamType { Id = 1, Name = "Club" },
                  new TeamType { Id = 2, Name = "Country" }
              );
        }
    }
}

