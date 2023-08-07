using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolRecords.Infrasctructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedenumschooling : Migration
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
                defaultValue: new DateTime(2023, 8, 6, 10, 9, 37, 478, DateTimeKind.Local).AddTicks(883),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 255,
                oldDefaultValue: new DateTime(2023, 8, 3, 18, 5, 15, 383, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Schoolings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Schoolings",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7298), "Infantil", 0 },
                    { 2, true, new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7336), "Fundamental", 0 },
                    { 3, true, new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7340), "Medio", 0 },
                    { 4, true, new DateTime(2023, 8, 7, 10, 9, 37, 477, DateTimeKind.Local).AddTicks(7343), "Supeior", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schoolings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Schoolings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime",
                maxLength: 255,
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 18, 5, 15, 383, DateTimeKind.Local).AddTicks(8258),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldMaxLength: 255,
                oldDefaultValue: new DateTime(2023, 8, 6, 10, 9, 37, 478, DateTimeKind.Local).AddTicks(883));
        }
    }
}
