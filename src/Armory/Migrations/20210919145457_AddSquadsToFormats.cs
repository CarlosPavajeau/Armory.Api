using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class AddSquadsToFormats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "squad_code",
                table: "war_material_delivery_certificate_formats",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "squad_code",
                table: "war_material_and_special_equipment_assignment_formats",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "squad_code",
                table: "assigned_weapon_magazine_formats",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_formats_squad_code",
                table: "war_material_delivery_certificate_formats",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squad_",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_formats_squad_code",
                table: "assigned_weapon_magazine_formats",
                column: "squad_code");

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                table: "war_material_delivery_certificate_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropIndex(
                name: "ix_war_material_delivery_certificate_formats_squad_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squad_",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropIndex(
                name: "ix_assigned_weapon_magazine_formats_squad_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropColumn(
                name: "squad_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropColumn(
                name: "squad_code",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropColumn(
                name: "squad_code",
                table: "assigned_weapon_magazine_formats");
        }
    }
}
