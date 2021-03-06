﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KTU.DataAccess;

namespace KTU.WebApp.Migrations
{
    [DbContext(typeof(SimpleDbContext))]
    partial class SimpleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KTU.Domain.User.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HouseNo");

                    b.Property<string>("PostCode");

                    b.Property<string>("Street");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("KTU.Domain.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("UserDetailId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("KTU.Domain.User.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<DateTime>("DayOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNo");

                    b.HasKey("Id");

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("KTU.Domain.User.UserImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserImage");
                });

            modelBuilder.Entity("KTU.Domain.User.Address", b =>
                {
                    b.HasOne("KTU.Domain.User.User", "User")
                        .WithMany("Address")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KTU.Domain.User.User", b =>
                {
                    b.HasOne("KTU.Domain.User.UserDetail", "UserDetail")
                        .WithOne("User")
                        .HasForeignKey("KTU.Domain.User.User", "UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KTU.Domain.User.UserImage", b =>
                {
                    b.HasOne("KTU.Domain.User.User", "User")
                        .WithMany("UserImage")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
