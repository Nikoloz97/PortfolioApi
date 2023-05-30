﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioApi.DbContexts;

#nullable disable

namespace PortfolioApi.Migrations
{
    [DbContext(typeof(ForumContext))]
    partial class ForumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PortfolioApi.Entities.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileCardID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProfileCardID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Plays the guitar",
                            ProfileCardID = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Picks up girls",
                            ProfileCardID = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Smokes weed and gets high",
                            ProfileCardID = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Watches movies",
                            ProfileCardID = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Loves melted cheese",
                            ProfileCardID = 3
                        },
                        new
                        {
                            Id = 6,
                            Description = "Prefers not to pull out",
                            ProfileCardID = 3
                        });
                });

            modelBuilder.Entity("PortfolioApi.Entities.ProfileCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProfileCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 30,
                            FirstName = "Future",
                            LastName = "Hendrix"
                        },
                        new
                        {
                            Id = 2,
                            Age = 22,
                            FirstName = "Drake",
                            LastName = "Parker"
                        },
                        new
                        {
                            Id = 3,
                            Age = 33,
                            FirstName = "Tom",
                            LastName = "Segura"
                        });
                });

            modelBuilder.Entity("PortfolioApi.Entities.Interest", b =>
                {
                    b.HasOne("PortfolioApi.Entities.ProfileCard", "ProfileCard")
                        .WithMany("Interests")
                        .HasForeignKey("ProfileCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileCard");
                });

            modelBuilder.Entity("PortfolioApi.Entities.ProfileCard", b =>
                {
                    b.Navigation("Interests");
                });
#pragma warning restore 612, 618
        }
    }
}
