﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Winery.Migrations
{
    [DbContext(typeof(WineryContext))]
    partial class WineryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CataWine", b =>
                {
                    b.Property<int>("CatasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VinosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CatasId", "VinosId");

                    b.HasIndex("VinosId");

                    b.ToTable("CataWine");
                });

            modelBuilder.Entity("Winery.Entities.Cata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CataId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CataId");

                    b.ToTable("Catas");
                });

            modelBuilder.Entity("Winery.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CataId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Winery.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Winery.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Winery.Entities.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Variety")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("CataWine", b =>
                {
                    b.HasOne("Winery.Entities.Cata", null)
                        .WithMany()
                        .HasForeignKey("CatasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Winery.Entities.Wine", null)
                        .WithMany()
                        .HasForeignKey("VinosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Winery.Entities.Cata", b =>
                {
                    b.HasOne("Winery.Entities.Cata", null)
                        .WithMany("Catas")
                        .HasForeignKey("CataId");
                });

            modelBuilder.Entity("Winery.Entities.Guest", b =>
                {
                    b.HasOne("Winery.Entities.Cata", "Cata")
                        .WithMany("Invitados")
                        .HasForeignKey("CataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cata");
                });

            modelBuilder.Entity("Winery.Entities.Cata", b =>
                {
                    b.Navigation("Catas");

                    b.Navigation("Invitados");
                });
#pragma warning restore 612, 618
        }
    }
}
