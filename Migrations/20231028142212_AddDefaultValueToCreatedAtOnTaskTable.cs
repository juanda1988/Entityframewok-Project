using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToCreatedAtOnTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tareas",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(7560),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"),
                column: "FechaCreacion",
                value: new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"),
                column: "FechaCreacion",
                value: new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(6900));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tareas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 10, 28, 9, 22, 12, 302, DateTimeKind.Local).AddTicks(7560));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e902"),
                column: "FechaCreacion",
                value: new DateTime(2023, 10, 28, 8, 55, 17, 843, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Tareas",
                keyColumn: "TareaId",
                keyValue: new Guid("671e734d-3b8d-4c76-b2df-3f2796e2e9f8"),
                column: "FechaCreacion",
                value: new DateTime(2023, 10, 28, 8, 55, 17, 843, DateTimeKind.Local).AddTicks(7950));
        }
    }
}
