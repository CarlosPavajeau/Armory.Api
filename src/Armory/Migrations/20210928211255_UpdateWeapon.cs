using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class UpdateWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "weapons");

            migrationBuilder.AddColumn<string>(
                name: "flight_code",
                table: "weapons",
                type: "varchar(50)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_weapons_flight_code",
                table: "weapons",
                column: "flight_code");

            migrationBuilder.AddForeignKey(
                name: "fk_weapons_flights_flight_code",
                table: "weapons",
                column: "flight_code",
                principalTable: "flights",
                principalColumn: "code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_weapons_flights_flight_code",
                table: "weapons");

            migrationBuilder.DropIndex(
                name: "ix_weapons_flight_code",
                table: "weapons");

            migrationBuilder.DropColumn(
                name: "flight_code",
                table: "weapons");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "weapons",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
