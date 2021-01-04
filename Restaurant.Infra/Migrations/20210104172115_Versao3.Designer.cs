﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Infra.Data;

namespace Restaurant.Infra.Migrations
{
    [DbContext(typeof(AppStoreContext))]
    [Migration("20210104172115_Versao3")]
    partial class Versao3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Restaurant.Core.Entities.RestaurantRatings.RestaurantRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2021, 1, 4, 14, 21, 15, 24, DateTimeKind.Local).AddTicks(2410));

                    b.Property<string>("EmailUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValue("200");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RestaurantRating");
                });

            modelBuilder.Entity("Restaurant.Core.Entities.Restaurants.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValue("200");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("IsCanceled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValue("200");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}
