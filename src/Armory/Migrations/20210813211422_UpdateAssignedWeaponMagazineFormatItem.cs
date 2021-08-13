using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class UpdateAssignedWeaponMagazineFormatItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AmmunitionLot",
                table: "AssignedWeaponMagazineFormatItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AmmunitionQuantity",
                table: "AssignedWeaponMagazineFormatItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmmunitionLot",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropColumn(
                name: "AmmunitionQuantity",
                table: "AssignedWeaponMagazineFormatItems");
        }
    }
}
