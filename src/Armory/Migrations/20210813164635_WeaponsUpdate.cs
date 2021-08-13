using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class WeaponsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityAvailable",
                table: "Weapons",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "TroopId",
                table: "Weapons",
                type: "varchar(10)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Lot",
                table: "Weapons",
                column: "Lot",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Series",
                table: "Weapons",
                column: "Series",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_TroopId",
                table: "Weapons",
                column: "TroopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Troopers_TroopId",
                table: "Weapons",
                column: "TroopId",
                principalTable: "Troopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Troopers_TroopId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_Lot",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_Series",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_TroopId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TroopId",
                table: "Weapons");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Weapons",
                newName: "QuantityAvailable");
        }
    }
}
