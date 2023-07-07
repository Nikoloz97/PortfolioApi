﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioApi.DbContexts;

#nullable disable

namespace PortfolioApi.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20230707151812_Alter_ProfileCardsxForumProfile_Created_Comments_Posts")]
    partial class Alter_ProfileCardsxForumProfile_Created_Comments_Posts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Flags")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ForumProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("CommentId");

                    b.HasIndex("ForumProfileId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileCardID")
                        .HasColumnType("INTEGER");

                    b.HasKey("InterestId");

                    b.HasIndex("ProfileCardID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Flags")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhotoURL")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfileCardID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("ProfileCardID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.ProfileCard", b =>
                {
                    b.Property<int>("ProfileCardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileURL")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProfileCardID");

                    b.HasIndex("UserId");

                    b.ToTable("ProfileCards");
                });

            modelBuilder.Entity("PortfolioApi.Entities.User.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfileURL")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProfileCardProfileCard", b =>
                {
                    b.Property<int>("FollowersProfileCardID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FollowingProfileCardID")
                        .HasColumnType("INTEGER");

                    b.HasKey("FollowersProfileCardID", "FollowingProfileCardID");

                    b.HasIndex("FollowingProfileCardID");

                    b.ToTable("ProfileCardProfileCard");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Comment", b =>
                {
                    b.HasOne("PortfolioApi.Entities.Forum.ProfileCard", "ForumProfile")
                        .WithMany()
                        .HasForeignKey("ForumProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioApi.Entities.Forum.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForumProfile");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Interest", b =>
                {
                    b.HasOne("PortfolioApi.Entities.Forum.ProfileCard", "ProfileCard")
                        .WithMany("Interests")
                        .HasForeignKey("ProfileCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfileCard");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Post", b =>
                {
                    b.HasOne("PortfolioApi.Entities.Forum.ProfileCard", "ForumProfile")
                        .WithMany("Posts")
                        .HasForeignKey("ProfileCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ForumProfile");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.ProfileCard", b =>
                {
                    b.HasOne("PortfolioApi.Entities.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProfileCardProfileCard", b =>
                {
                    b.HasOne("PortfolioApi.Entities.Forum.ProfileCard", null)
                        .WithMany()
                        .HasForeignKey("FollowersProfileCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioApi.Entities.Forum.ProfileCard", null)
                        .WithMany()
                        .HasForeignKey("FollowingProfileCardID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PortfolioApi.Entities.Forum.ProfileCard", b =>
                {
                    b.Navigation("Interests");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}