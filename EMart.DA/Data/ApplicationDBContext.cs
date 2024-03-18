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
        public DbSet<Player> Players { get; set; }
        public DbSet<Specific> Specifics { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<League> Leagues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamType>().HasData(
                  new TeamType { Id = 1, Name = "Club" },
                  new TeamType { Id = 2, Name = "Country" }
              );


            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Lionel Messi" },
                new Player { Id = 2, Name = "Cristiano Ronaldo" },
                new Player { Id = 3, Name = "Neymar Jr" },
                new Player { Id = 4, Name = "Kylian Mbappé" },
                new Player { Id = 5, Name = "Robert Lewandowski" },
                new Player { Id = 6, Name = "Kevin De Bruyne" },
                new Player { Id = 7, Name = "Mohamed Salah" },
                new Player { Id = 8, Name = "Sadio Mané" },
                new Player { Id = 9, Name = "Sergio Ramos" },
                new Player { Id = 10, Name = "Luka Modrić" },
                new Player { Id = 11, Name = "Virgil van Dijk" },
                new Player { Id = 12, Name = "Harry Kane" },
                new Player { Id = 13, Name = "Antoine Griezmann" },
                new Player { Id = 14, Name = "Eden Hazard" },
                new Player { Id = 15, Name = "Raheem Sterling" },
                new Player { Id = 16, Name = "Manuel Neuer" },
                new Player { Id = 17, Name = "Trent Alexander-Arnold" },
                new Player { Id = 18, Name = "Marc-André ter Stegen" },
                new Player { Id = 19, Name = "Son Heung-min" },
                new Player { Id = 20, Name = "Alisson Becker" },
                new Player { Id = 21, Name = "Frenkie de Jong" },
                new Player { Id = 22, Name = "Bernardo Silva" },
                new Player { Id = 23, Name = "João Félix" },
                new Player { Id = 24, Name = "Paul Pogba" },
                new Player { Id = 25, Name = "Jan Oblak" },
                new Player { Id = 26, Name = "Sergio Agüero" },
                new Player { Id = 27, Name = "Bruno Fernandes" },
                new Player { Id = 28, Name = "Edinson Cavani" },
                new Player { Id = 29, Name = "Thiago Alcântara" },
                new Player { Id = 30, Name = "Timo Werner" },
                new Player { Id = 31, Name = "Romelu Lukaku" },
                new Player { Id = 32, Name = "Joshua Kimmich" },
                new Player { Id = 33, Name = "Jamie Vardy" },
                new Player { Id = 34, Name = "Vinícius Júnior" },
                new Player { Id = 35, Name = "Riyad Mahrez" },
                new Player { Id = 36, Name = "Thibaut Courtois" },
                new Player { Id = 37, Name = "Kalidou Koulibaly" },
                new Player { Id = 38, Name = "Jadon Sancho" },
                new Player { Id = 39, Name = "Ciro Immobile" },
                new Player { Id = 40, Name = "Miralem Pjanić" },
                new Player { Id = 41, Name = "Sergio Busquets" },
                new Player { Id = 42, Name = "Dries Mertens" },
                new Player { Id = 43, Name = "Gianluigi Donnarumma" },
                new Player { Id = 44, Name = "N'Golo Kanté" },
                new Player { Id = 45, Name = "Andy Robertson" },
                new Player { Id = 46, Name = "Hakim Ziyech" },
                new Player { Id = 47, Name = "Angel Di Maria" },
                new Player { Id = 48, Name = "Alex Telles" },
                new Player { Id = 49, Name = "Marquinhos" },
                new Player { Id = 50, Name = "Gerard Piqué" }
            );


            modelBuilder.Entity<Specific>().HasData(
                new Specific { Id = 1, Name = "Vintage" },
                new Specific { Id = 2, Name = "Legend" },
                new Specific { Id = 3, Name = "Hero" }
            );


            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Adidas" },
                new Brand { Id = 2, Name = "Nike" },
                new Brand { Id = 3, Name = "Puma" },
                new Brand { Id = 4, Name = "Under Armour" },
                new Brand { Id = 5, Name = "New Balance" }
            );


            modelBuilder.Entity<Edition>().HasData(
               new Edition { Id = 1, Name = "World Cup" },
               new Edition { Id = 2, Name = "Champions League" },
               new Edition { Id=3, Name="New Collection"}
           );


        }

    }

}

