﻿// <auto-generated />
using System;
using EMigrant.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMigrant.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211127163417_MigraInicial2.2")]
    partial class MigraInicial22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EMigrant.App.Dominio.Amigos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AmigoId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoFamiliarId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("GrupoFamiliarId");

                    b.ToTable("Amigos");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.Familias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FamiliarId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoFamiliarId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("GrupoFamiliarId");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.GrupoFamiliar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("id");

                    b.ToTable("Familiares");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.Migrante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GrupoFamiliarId")
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccionActual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccionElectronica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paisOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("situacionLaboral")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoIdentificacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("GrupoFamiliarId");

                    b.ToTable("Migrantes");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.Amigos", b =>
                {
                    b.HasOne("EMigrant.App.Dominio.GrupoFamiliar", "grupoFamiliar")
                        .WithMany("amigos")
                        .HasForeignKey("GrupoFamiliarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupoFamiliar");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.Familias", b =>
                {
                    b.HasOne("EMigrant.App.Dominio.GrupoFamiliar", "grupoFamiliar")
                        .WithMany("familias")
                        .HasForeignKey("GrupoFamiliarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("grupoFamiliar");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.Migrante", b =>
                {
                    b.HasOne("EMigrant.App.Dominio.GrupoFamiliar", "GrupoFamiliar")
                        .WithMany()
                        .HasForeignKey("GrupoFamiliarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoFamiliar");
                });

            modelBuilder.Entity("EMigrant.App.Dominio.GrupoFamiliar", b =>
                {
                    b.Navigation("amigos");

                    b.Navigation("familias");
                });
#pragma warning restore 612, 618
        }
    }
}
