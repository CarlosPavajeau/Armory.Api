using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class RemoveWeaponLot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_weapons_lot",
                table: "weapons");

            migrationBuilder.DropColumn(
                name: "lot",
                table: "weapons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lot",
                table: "weapons",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_weapons_lot",
                table: "weapons",
                column: "lot",
                unique: true);
        }
    }
}
