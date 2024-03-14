﻿// <auto-generated />
using EMart.DA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EMart.DA.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240314121443_EditionMigration")]
    partial class EditionMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EMart.Models.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Puma"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Under Armour"
                        },
                        new
                        {
                            Id = 5,
                            Name = "New Balance"
                        });
                });

            modelBuilder.Entity("EMart.Models.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EMart.Models.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "World Cup"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Champions League"
                        },
                        new
                        {
                            Id = 3,
                            Name = "New Collection"
                        });
                });

            modelBuilder.Entity("EMart.Models.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lionel Messi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cristiano Ronaldo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Neymar Jr"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kylian Mbappé"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Robert Lewandowski"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Kevin De Bruyne"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Mohamed Salah"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sadio Mané"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sergio Ramos"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Luka Modrić"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Virgil van Dijk"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Harry Kane"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Antoine Griezmann"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Eden Hazard"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Raheem Sterling"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Manuel Neuer"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Trent Alexander-Arnold"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Marc-André ter Stegen"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Son Heung-min"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Alisson Becker"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Frenkie de Jong"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Bernardo Silva"
                        },
                        new
                        {
                            Id = 23,
                            Name = "João Félix"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Paul Pogba"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Jan Oblak"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Sergio Agüero"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Bruno Fernandes"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Edinson Cavani"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Thiago Alcântara"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Timo Werner"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Romelu Lukaku"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Joshua Kimmich"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Jamie Vardy"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Vinícius Júnior"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Riyad Mahrez"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Thibaut Courtois"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Kalidou Koulibaly"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Jadon Sancho"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Ciro Immobile"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Miralem Pjanić"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Sergio Busquets"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Dries Mertens"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Gianluigi Donnarumma"
                        },
                        new
                        {
                            Id = 44,
                            Name = "N'Golo Kanté"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Andy Robertson"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Hakim Ziyech"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Angel Di Maria"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Alex Telles"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Marquinhos"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Gerard Piqué"
                        });
                });

            modelBuilder.Entity("EMart.Models.Models.Specific", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specifics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vintage"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Legend"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hero"
                        });
                });

            modelBuilder.Entity("EMart.Models.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamTypeId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EMart.Models.Models.TeamType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeamTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Club"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Country"
                        });
                });

            modelBuilder.Entity("EMart.Models.Models.Team", b =>
                {
                    b.HasOne("EMart.Models.Models.TeamType", "Type")
                        .WithMany()
                        .HasForeignKey("TeamTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}
