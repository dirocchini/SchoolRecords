using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", maxLength: 255, nullable: false, defaultValue: new DateTime(2023, 8, 3, 18, 5, 15, 383, DateTimeKind.Local).AddTicks(8258)),
                    SchoolingId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                name: "IX_Users_Id",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SchoolingId",
                table: "Users",
                column: "SchoolingId",
                unique: true,
                filter: "[SchoolingId] IS NOT NULL");

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
