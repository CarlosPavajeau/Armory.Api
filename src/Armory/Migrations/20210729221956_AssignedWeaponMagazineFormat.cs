using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Armory.Migrations
{
    public partial class AssignedWeaponMagazineFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssignedWeaponMagazineFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    SquadCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Warehouse = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedWeaponMagazineFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedWeaponMagazineFormats_Squadrons_SquadronCode",
                        column: x => x.SquadronCode,
                        principalTable: "Squadrons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedWeaponMagazineFormats_Squads_SquadCode",
                        column: x => x.SquadCode,
                        principalTable: "Squads",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignedWeaponMagazineFormatItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TroopId = table.Column<string>(type: "varchar(10)", nullable: false),
                    CartridgeOfLife = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VerifiedInPhysical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Novelty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Observations = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true),
                    AssignedWeaponMagazineFormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedWeaponMagazineFormatItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~",
                        column: x => x.AssignedWeaponMagazineFormatId,
                        principalTable: "AssignedWeaponMagazineFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignedWeaponMagazineFormatItems_Troopers_TroopId",
                        column: x => x.TroopId,
                        principalTable: "Troopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~",
                table: "AssignedWeaponMagazineFormatItems",
                column: "AssignedWeaponMagazineFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_TroopId",
                table: "AssignedWeaponMagazineFormatItems",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedWeaponMagazineFormats_SquadCode",
                table: "AssignedWeaponMagazineFormats",
                column: "SquadCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedWeaponMagazineFormats_SquadronCode",
                table: "AssignedWeaponMagazineFormats",
                column: "SquadronCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropTable(
                name: "AssignedWeaponMagazineFormats");
        }
    }
}
