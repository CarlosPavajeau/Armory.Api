using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class ChangeSeriesBySerial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_series",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "weapons",
                newName: "serial");

            migrationBuilder.RenameColumn(
                name: "weapon_series",
                table: "war_material_delivery_certificate_format_weapons",
                newName: "weapon_serial");

            migrationBuilder.RenameColumn(
                name: "equipment_series",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "equipment_serial");

            migrationBuilder.RenameColumn(
                name: "weapon_series",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "weapon_serial");

            migrationBuilder.RenameColumn(
                name: "equipment_series",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "equipment_serial");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "equipments",
                newName: "serial");

            migrationBuilder.RenameColumn(
                name: "weapon_series",
                table: "assigned_weapon_magazine_format_items",
                newName: "weapon_serial");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_format_items_weapon_series",
                table: "assigned_weapon_magazine_format_items",
                newName: "ix_assigned_weapon_magazine_format_items_weapon_serial");

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_serial",
                table: "assigned_weapon_magazine_format_items",
                column: "weapon_serial",
                principalTable: "weapons",
                principalColumn: "serial",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_serial",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.RenameColumn(
                name: "serial",
                table: "weapons",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "weapon_serial",
                table: "war_material_delivery_certificate_format_weapons",
                newName: "weapon_series");

            migrationBuilder.RenameColumn(
                name: "equipment_serial",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "equipment_series");

            migrationBuilder.RenameColumn(
                name: "weapon_serial",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "weapon_series");

            migrationBuilder.RenameColumn(
                name: "equipment_serial",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "equipment_series");

            migrationBuilder.RenameColumn(
                name: "serial",
                table: "equipments",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "weapon_serial",
                table: "assigned_weapon_magazine_format_items",
                newName: "weapon_series");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_format_items_weapon_serial",
                table: "assigned_weapon_magazine_format_items",
                newName: "ix_assigned_weapon_magazine_format_items_weapon_series");

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_series",
                table: "assigned_weapon_magazine_format_items",
                column: "weapon_series",
                principalTable: "weapons",
                principalColumn: "series",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
