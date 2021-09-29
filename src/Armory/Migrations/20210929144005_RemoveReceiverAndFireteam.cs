using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class RemoveReceiverAndFireteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_troope",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_troop_",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropColumn(
                name: "fireteam_code",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropColumn(
                name: "troop_id",
                table: "war_material_and_special_equipment_assignment_formats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fireteam_code",
                table: "war_material_and_special_equipment_assignment_formats",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "troop_id",
                table: "war_material_and_special_equipment_assignment_formats",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "fireteam_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_troop_",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "troop_id");

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "fireteam_code",
                principalTable: "fireteams",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_troope",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "troop_id",
                principalTable: "troopers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
