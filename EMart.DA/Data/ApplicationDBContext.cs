using EMart.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMart.DA.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
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
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }


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
                new Player { Id = 50, Name = "Gerard Piqué" },
                new Player { Id = 52, Name = "Keylor Navas" },
new Player { Id = 53, Name = "Sergio Ramos" },
new Player { Id = 54, Name = "David Alaba" },
new Player { Id = 55, Name = "Luis Suárez" },
new Player { Id = 56, Name = "Marco Reus" },
new Player { Id = 57, Name = "Fabinho" },
new Player { Id = 58, Name = "Kai Havertz" },
new Player { Id = 59, Name = "Angel Di Maria" },
new Player { Id = 60, Name = "Edinson Cavani" },
new Player { Id = 61, Name = "Lucas Hernández" },
new Player { Id = 62, Name = "Memphis Depay" },
new Player { Id = 63, Name = "Leroy Sané" },
new Player { Id = 64, Name = "Kasper Schmeichel" },
new Player { Id = 65, Name = "Koke" },
new Player { Id = 66, Name = "Aymeric Laporte" },
new Player { Id = 67, Name = "Nicolò Barella" },
new Player { Id = 68, Name = "Matthijs de Ligt" },
new Player { Id = 69, Name = "Rodrigo Bentancur" },
new Player { Id = 70, Name = "Alejandro Gómez" },
new Player { Id = 71, Name = "Raphael Varane" },
new Player { Id = 72, Name = "Jude Bellingham" },
new Player { Id = 73, Name = "Trent Alexander-Arnold" },
new Player { Id = 74, Name = "João Cancelo" },
new Player { Id = 75, Name = "Dani Carvajal" },
new Player { Id = 76, Name = "Casemiro" },
new Player { Id = 77, Name = "Erling Haaland" },
new Player { Id = 78, Name = "Jack Grealish" },
new Player { Id = 79, Name = "Wojciech Szczęsny" },
new Player { Id = 80, Name = "Ángel Correa" },
new Player { Id = 81, Name = "Lorenzo Insigne" },
new Player { Id = 82, Name = "Saul Niguez" },
new Player { Id = 83, Name = "Allan Saint-Maximin" },
new Player { Id = 84, Name = "N'Golo Kanté" },
new Player { Id = 85, Name = "Jorginho" },
new Player { Id = 86, Name = "Timo Werner" },
new Player { Id = 87, Name = "Ferran Torres" },
new Player { Id = 88, Name = "Jamie Vardy" },
new Player { Id = 89, Name = "Pierre-Emerick Aubameyang" },
new Player { Id = 90, Name = "Karim Benzema" },
new Player { Id = 91, Name = "Romelu Lukaku" },
new Player { Id = 92, Name = "Jadon Sancho" },
new Player { Id = 93, Name = "Gareth Bale" },
new Player { Id = 94, Name = "David de Gea" },
new Player { Id = 95, Name = "Timo Werner" },
new Player { Id = 96, Name = "Sadio Mané" },
new Player { Id = 97, Name = "Raphaël Guerreiro" },
new Player { Id = 98, Name = "Serge Gnabry" },
new Player { Id = 99, Name = "Achraf Hakimi" },
new Player { Id = 100, Name = "Yann Sommer" },
new Player { Id = 101, Name = "Erling Haaland" },
new Player { Id = 51, Name = "None" }

                  );


            modelBuilder.Entity<Specific>().HasData(
                new Specific { Id = 1, Name = "Vintage" },
                new Specific { Id = 2, Name = "Legend" },
                new Specific { Id = 3, Name = "Hero" },
                new Specific { Id = 4, Name = "None" }
            );


            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Adidas" },
                new Brand { Id = 2, Name = "Nike" },
                new Brand { Id = 3, Name = "Puma" },
                new Brand { Id = 4, Name = "Under Armour" },
                new Brand { Id = 5, Name = "New Balance" },
                new Brand { Id = 6, Name = "None" }
            );


            modelBuilder.Entity<Edition>().HasData(
               new Edition { Id = 1, Name = "World Cup" },
               new Edition { Id = 2, Name = "Champions League" },
               new Edition { Id = 3, Name = "New Collection" },
               new Edition { Id = 4, Name = "None" }
           );

            modelBuilder.Entity<Size>().HasData(
               new Size { Id = 1, Sizes = "XS", IsActive = true },
               new Size { Id = 2, Sizes = "S", IsActive = true },
               new Size { Id = 3, Sizes = "M", IsActive = true },
               new Size { Id = 4, Sizes = "L", IsActive = true },
               new Size { Id = 5, Sizes = "XL", IsActive = true },
               new Size { Id = 6, Sizes = "2XL", IsActive = true },
               new Size { Id = 7, Sizes = "3XL", IsActive = true }
           );


        }

    }

}

