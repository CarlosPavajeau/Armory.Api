using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class AddWeaponToAssignedWeaponMagazineFormatItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WeaponCode",
                table: "AssignedWeaponMagazineFormatItems",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems",
                column: "WeaponCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Weapons_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems",
                column: "WeaponCode",
                principalTable: "Weapons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Weapons_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropColumn(
                name: "WeaponCode",
                table: "AssignedWeaponMagazineFormatItems");
        }
    }
}
