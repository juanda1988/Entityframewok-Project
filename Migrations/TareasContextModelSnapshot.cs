﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using proyectoef;

#nullable disable

namespace proyectoef.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"),
                            Descripcion = "Actividades que se deben realizar en el dia",
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"),
                            Descripcion = "Actividades que se deben realizar en la semana",
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValue(new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(7560));

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"),
                            CategoriaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"),
                            Descripcion = "Pagar antes del 20 de cada mes",
                            FechaCreacion = new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(6900),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"),
                            CategoriaId = new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"),
                            Descripcion = "La debo terminar de ver",
                            FechaCreacion = new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(6930),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver pelicula"
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
