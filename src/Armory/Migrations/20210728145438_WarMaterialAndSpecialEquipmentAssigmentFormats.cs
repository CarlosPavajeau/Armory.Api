using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Armory.Migrations
{
    public partial class WarMaterialAndSpecialEquipmentAssigmentFormats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime", nullable: false),
                    Place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SquadCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TroopId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Warehouse = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    DocMovement = table.Column<int>(type: "int", nullable: false),
                    PhysicalLocation = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Others = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squadrons_Sq~",
                        column: x => x.SquadronCode,
                        principalTable: "Squadrons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squads_Squad~",
                        column: x => x.SquadCode,
                        principalTable: "Squads",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Troopers_Tro~",
                        column: x => x.TroopId,
                        principalTable: "Troopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    AmmunitionCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition", x => new { x.AmmunitionCode, x.WarMaterialAndSpecialEquipmentAssignmentFormatId });
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_Amm~",
                        column: x => x.AmmunitionCode,
                        principalTable: "Ammunition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~",
                        column: x => x.WarMaterialAndSpecialEquipmentAssignmentFormatId,
                        principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments", x => new { x.WarMaterialAndSpecialEquipmentAssignmentFormatId, x.EquipmentCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~",
                        column: x => x.EquipmentCode,
                        principalTable: "Equipments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_War~",
                        column: x => x.WarMaterialAndSpecialEquipmentAssignmentFormatId,
                        principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    ExplosiveCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives", x => new { x.WarMaterialAndSpecialEquipmentAssignmentFormatId, x.ExplosiveCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~",
                        column: x => x.ExplosiveCode,
                        principalTable: "Explosives",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_War~",
                        column: x => x.WarMaterialAndSpecialEquipmentAssignmentFormatId,
                        principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapon",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatsId = table.Column<int>(type: "int", nullable: false),
                    WeaponsCode = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapon", x => new { x.WarMaterialAndSpecialEquipmentAssignmentFormatsId, x.WeaponsCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapon_WarMate~",
                        column: x => x.WarMaterialAndSpecialEquipmentAssignmentFormatsId,
                        principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapon_Weapons~",
                        column: x => x.WeaponsCode,
                        principalTable: "Weapons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                column: "WarMaterialAndSpecialEquipmentAssignmentFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                column: "EquipmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                column: "ExplosiveCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadCode",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "SquadCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadronCode",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "SquadronCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_TroopId",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatWeapon_Weapons~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapon",
                column: "WeaponsCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapon");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormats");
        }
    }
}
