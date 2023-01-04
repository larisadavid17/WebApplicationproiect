﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationproiect.Data;

#nullable disable

namespace WebApplicationproiect.Migrations
{
    [DbContext(typeof(WebApplicationproiectContext))]
    [Migration("20230104153934_ps")]
    partial class ps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplicationproiect.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Cursuri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experienta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeleServiciului")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.Specializare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireSpecializare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.SpecializareServiciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ServiciuID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ServiciuID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("SpecializareServiciu");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.Angajat", b =>
                {
                    b.HasOne("WebApplicationproiect.Models.Specializare", "Specializare")
                        .WithMany("Angajati")
                        .HasForeignKey("SpecializareID");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.SpecializareServiciu", b =>
                {
                    b.HasOne("WebApplicationproiect.Models.Serviciu", "Serviciu")
                        .WithMany("SpecializareServicii")
                        .HasForeignKey("ServiciuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplicationproiect.Models.Specializare", "Specializare")
                        .WithMany("SpecializareServicii")
                        .HasForeignKey("SpecializareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Serviciu");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.Serviciu", b =>
                {
                    b.Navigation("SpecializareServicii");
                });

            modelBuilder.Entity("WebApplicationproiect.Models.Specializare", b =>
                {
                    b.Navigation("Angajati");

                    b.Navigation("SpecializareServicii");
                });
#pragma warning restore 612, 618
        }
    }
}
