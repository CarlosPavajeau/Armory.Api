using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class RenameEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squadrons_squadron_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_troopers_squads_squad_code",
                table: "troopers");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squadr",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squadrons_squadron",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropTable(
                name: "squads");

            migrationBuilder.DropTable(
                name: "squadrons");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "war_material_delivery_certificate_formats",
                newName: "flight_code");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "war_material_delivery_certificate_formats",
                newName: "fireteam_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_squadron_code",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_flight_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_squad_code",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_fireteam_code");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "flight_code");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "fireteam_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squadr",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_flight");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squad_",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_firete");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "troopers",
                newName: "fireteam_code");

            migrationBuilder.RenameIndex(
                name: "ix_troopers_squad_code",
                table: "troopers",
                newName: "ix_troopers_fireteam_code");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "assigned_weapon_magazine_formats",
                newName: "flight_code");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "assigned_weapon_magazine_formats",
                newName: "fireteam_code");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_squadron_code",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_flight_code");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_squad_code",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_fireteam_code");

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flights", x => x.code);
                    table.ForeignKey(
                        name: "fk_flights_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fireteams",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fireteams", x => x.code);
                    table.ForeignKey(
                        name: "fk_fireteams_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fireteams_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_fireteams_flight_code",
                table: "fireteams",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_fireteams_person_id",
                table: "fireteams",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_flights_person_id",
                table: "flights",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_fireteams_fireteam_code",
                table: "assigned_weapon_magazine_formats",
                column: "fireteam_code",
                principalTable: "fireteams",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_flights_flight_code",
                table: "assigned_weapon_magazine_formats",
                column: "flight_code",
                principalTable: "flights",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_troopers_fireteams_fireteam_code",
                table: "troopers",
                column: "fireteam_code",
                principalTable: "fireteams",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "fireteam_code",
                principalTable: "fireteams",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_flight",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "flight_code",
                principalTable: "flights",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_fireteams_fireteam",
                table: "war_material_delivery_certificate_formats",
                column: "fireteam_code",
                principalTable: "fireteams",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_flights_flight_code",
                table: "war_material_delivery_certificate_formats",
                column: "flight_code",
                principalTable: "flights",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_fireteams_fireteam_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_flights_flight_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_troopers_fireteams_fireteam_code",
                table: "troopers");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_flight",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_fireteams_fireteam",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_flights_flight_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropTable(
                name: "fireteams");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.RenameColumn(
                name: "flight_code",
                table: "war_material_delivery_certificate_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "fireteam_code",
                table: "war_material_delivery_certificate_formats",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_flight_code",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_squadron_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_fireteam_code",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_squad_code");

            migrationBuilder.RenameColumn(
                name: "flight_code",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "fireteam_code",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_flight",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_squadr");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_squad_");

            migrationBuilder.RenameColumn(
                name: "fireteam_code",
                table: "troopers",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "ix_troopers_fireteam_code",
                table: "troopers",
                newName: "ix_troopers_squad_code");

            migrationBuilder.RenameColumn(
                name: "flight_code",
                table: "assigned_weapon_magazine_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "fireteam_code",
                table: "assigned_weapon_magazine_formats",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_flight_code",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_squadron_code");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_fireteam_code",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_squad_code");

            migrationBuilder.CreateTable(
                name: "squadrons",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_squadrons", x => x.code);
                    table.ForeignKey(
                        name: "fk_squadrons_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "squads",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    squadron_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_squads", x => x.code);
                    table.ForeignKey(
                        name: "fk_squads_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_squads_squadrons_squadron_code",
                        column: x => x.squadron_code,
                        principalTable: "squadrons",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_squadrons_person_id",
                table: "squadrons",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_squads_person_id",
                table: "squads",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_squads_squadron_code",
                table: "squads",
                column: "squadron_code");

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squadrons_squadron_code",
                table: "assigned_weapon_magazine_formats",
                column: "squadron_code",
                principalTable: "squadrons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_troopers_squads_squad_code",
                table: "troopers",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squadr",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squadron_code",
                principalTable: "squadrons",
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
                name: "fk_war_material_delivery_certificate_formats_squadrons_squadron",
                table: "war_material_delivery_certificate_formats",
                column: "squadron_code",
                principalTable: "squadrons",
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
    }
}
