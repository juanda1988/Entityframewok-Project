using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"), "Actividades que se deben realizar en la semana", "Actividades personales", 50 },
                    { new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), "Actividades que se deben realizar en el dia", "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"), new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"), "La debo terminar de ver", new DateTime(2023, 10, 28, 8, 55, 17, 843, DateTimeKind.Local).AddTicks(7980), 0, "Terminar de ver pelicula" },
                    { new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"), "Pagar antes del 20 de cada mes", new DateTime(2023, 10, 28, 8, 55, 17, 843, DateTimeKind.Local).AddTicks(7950), 1, "Pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"));

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"));
        }
    }
}
