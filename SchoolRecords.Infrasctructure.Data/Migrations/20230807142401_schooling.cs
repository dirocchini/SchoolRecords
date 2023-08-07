using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolRecords.Infrasctructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class schooling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime",
                maxLength: 255,
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(8132),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 255,
                oldDefaultValue: new DateTime(2023, 8, 6, 10, 9, 37, 478, DateTimeKind.Local).AddTicks(883));

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1183), "Ensino Infantil", 1 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1241), "Ensino Fundamental", 2 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1251), "Ensino Médio", 3 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(1257), "Ensino Supeior", 4 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime",
                maxLength: 255,
                nullable: false,
                defaultValue: new DateTime(2023, 8, 6, 10, 9, 37, 478, DateTimeKind.Local).AddTicks(883),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 255,
                oldDefaultValue: new DateTime(2023, 8, 6, 11, 24, 0, 834, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7298), "Infantil", 0 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7336), "Fundamental", 0 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7340), "Medio", 0 });

            migrationBuilder.UpdateData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Description", "Type" },
                values: new object[] { new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7343), "Supeior", 0 });
        }
    }
}
