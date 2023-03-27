﻿// <auto-generated />
using System;
using Fly.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fly.Data.Migrations
{
    [DbContext(typeof(FlyDbContext))]
    [Migration("20221205094034_AddedDateTimeFlewAndArrive")]
    partial class AddedDateTimeFlewAndArrive
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fly.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Arrive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Flew")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaneId");

                    b.HasIndex("UserId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Fly.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "the simple plane from hasdata method",
                            Image = "https://rukikryki.ru/wp-content/uploads/posts/2018-03/1520082789_08ef1025ce2757b51ff93bb9e7d4dfc0-the-airplane-bald-eagle.jpg",
                            Name = "Plane of HASDATA"
                        });
                });

            modelBuilder.Entity("Fly.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Login = "Administrator-1@admin.admin",
                            Name = "Admin",
                            Password = "c2ef3e415f01b83cf65108505daefccb0e032ccb1aabf45ac0541426a56dbfa5",
                            Role = 1
                        });
                });

            modelBuilder.Entity("Fly.Flight", b =>
                {
                    b.HasOne("Fly.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fly.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plane");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
