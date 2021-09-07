using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class RenameCartridgeOfLifeBySafetyCartridge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cartridge_of_life",
                table: "assigned_weapon_magazine_format_items",
                newName: "safety_cartridge");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "safety_cartridge",
                table: "assigned_weapon_magazine_format_items",
                newName: "cartridge_of_life");
        }
    }
}
