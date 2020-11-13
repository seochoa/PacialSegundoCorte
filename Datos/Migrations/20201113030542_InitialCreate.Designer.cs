﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(PersonaContext))]
    [Migration("20201113030542_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Fechanac")
                        .HasColumnType("datetime2");

                    b.Property<string>("Institucion")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombreacudiente")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tipodocumeto")
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Documento");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.Property<string>("Idvacuna")
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Edadaplicacion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechavacuna")
                        .HasColumnType("datetime2");

                    b.Property<string>("PersonaDocumento")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tipovacuna")
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Idvacuna");

                    b.HasIndex("PersonaDocumento");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Entidad.Vacuna", b =>
                {
                    b.HasOne("Entidad.Persona", null)
                        .WithMany("Vacunas")
                        .HasForeignKey("PersonaDocumento");
                });
#pragma warning restore 612, 618
        }
    }
}
