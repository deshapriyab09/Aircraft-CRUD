using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AircraftAPI.DataAccess.Migrations
{
    public partial class AddedDataAnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "DateTime", "Location", "Make", "Model", "PhotoPath", "Registration" },
                values: new object[] { 1, new DateTime(2021, 11, 10, 13, 4, 1, 575, DateTimeKind.Local).AddTicks(6944), "London Gatwick", "Boeing", "777-300ER", null, "G-RNAC”" });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "DateTime", "Location", "Make", "Model", "PhotoPath", "Registration" },
                values: new object[] { 2, new DateTime(2021, 11, 10, 13, 4, 1, 576, DateTimeKind.Local).AddTicks(3912), "London Gatwick1", "Boeing1", "777-300ER1", null, "G-RNAC1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");
        }
    }
}
