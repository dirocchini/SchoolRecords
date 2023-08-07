using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolRecords.Infrasctructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schoolings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schoolings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Format = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", maxLength: 255, nullable: false),
                    SchoolingId = table.Column<int>(type: "int", nullable: false),
                    SchoolRecordId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SchoolRecords_SchoolRecordId",
                        column: x => x.SchoolRecordId,
                        principalTable: "SchoolRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Schoolings_SchoolingId",
                        column: x => x.SchoolingId,
                        principalTable: "Schoolings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Schoolings",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Type" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensino Infantil", 1 },
                    { 2, true, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensino Fundamental", 2 },
                    { 3, true, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensino Médio", 3 },
                    { 4, true, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ensino Superior", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schoolings_Id",
                table: "Schoolings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRecords_Id",
                table: "SchoolRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolingId",
                table: "Users",
                column: "SchoolingId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolRecordId",
                table: "Users",
                column: "SchoolRecordId",
                unique: true,
                filter: "[SchoolRecordId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SchoolRecords");

            migrationBuilder.DropTable(
                name: "Schoolings");
        }
    }
}
