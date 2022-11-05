﻿// <auto-generated />
using System;
using KeyRotation.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KeyRotation.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KeyRotation.Database.MyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("MyEntities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("258492ae-0133-47fc-b3f1-75c0ac33a291"),
                            Date = new DateTime(2022, 11, 18, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7687),
                            Name = "Fund 1"
                        },
                        new
                        {
                            Id = new Guid("f55add9c-350a-4b14-bd1d-f13aca067846"),
                            Date = new DateTime(2022, 12, 3, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7702),
                            Name = "Fund 2"
                        },
                        new
                        {
                            Id = new Guid("e867c517-ce35-4fe5-8cae-b944dbfd9d54"),
                            Date = new DateTime(2022, 12, 18, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7705),
                            Name = "Fund 3"
                        },
                        new
                        {
                            Id = new Guid("f2b16552-389a-442c-a176-ee46b3ce53a7"),
                            Date = new DateTime(2023, 1, 2, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7706),
                            Name = "Fund 4"
                        },
                        new
                        {
                            Id = new Guid("952347f8-11af-4bf3-ab62-91e9794d56ec"),
                            Date = new DateTime(2023, 1, 17, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7707),
                            Name = "Fund 5"
                        },
                        new
                        {
                            Id = new Guid("59d1e381-5484-4580-9eb4-8fc364075225"),
                            Date = new DateTime(2023, 2, 1, 23, 14, 3, 492, DateTimeKind.Local).AddTicks(7708),
                            Name = "Fund 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}