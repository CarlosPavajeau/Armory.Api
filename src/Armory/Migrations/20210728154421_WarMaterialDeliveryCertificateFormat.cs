using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Armory.Migrations
{
    public partial class WarMaterialDeliveryCertificateFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Validity = table.Column<DateTime>(type: "datetime", nullable: false),
                    Place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    SquadCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    TroopId = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormats_Squadrons_SquadronCode",
                        column: x => x.SquadronCode,
                        principalTable: "Squadrons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormats_Squads_SquadCode",
                        column: x => x.SquadCode,
                        principalTable: "Squads",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormats_Troopers_TroopId",
                        column: x => x.TroopId,
                        principalTable: "Troopers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatAmmunition",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    AmmunitionCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormatAmmunition", x => new { x.WarMaterialDeliveryCertificateFormatId, x.AmmunitionCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_Ammunition_Am~",
                        column: x => x.AmmunitionCode,
                        principalTable: "Ammunition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_WarMaterialDe~",
                        column: x => x.WarMaterialDeliveryCertificateFormatId,
                        principalTable: "WarMaterialDeliveryCertificateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatEquipments",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormatEquipments", x => new { x.WarMaterialDeliveryCertificateFormatId, x.EquipmentCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatEquipments_Equipments_Eq~",
                        column: x => x.EquipmentCode,
                        principalTable: "Equipments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatEquipments_WarMaterialDe~",
                        column: x => x.WarMaterialDeliveryCertificateFormatId,
                        principalTable: "WarMaterialDeliveryCertificateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatExplosives",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    ExplosiveCode = table.Column<string>(type: "varchar(50)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormatExplosives", x => new { x.WarMaterialDeliveryCertificateFormatId, x.ExplosiveCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatExplosives_Explosives_Ex~",
                        column: x => x.ExplosiveCode,
                        principalTable: "Explosives",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatExplosives_WarMaterialDe~",
                        column: x => x.WarMaterialDeliveryCertificateFormatId,
                        principalTable: "WarMaterialDeliveryCertificateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatWeapon",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatsId = table.Column<int>(type: "int", nullable: false),
                    WeaponsCode = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormatWeapon", x => new { x.WarMaterialDeliveryCertificateFormatsId, x.WeaponsCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatWeapon_WarMaterialDelive~",
                        column: x => x.WarMaterialDeliveryCertificateFormatsId,
                        principalTable: "WarMaterialDeliveryCertificateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatWeapon_Weapons_WeaponsCo~",
                        column: x => x.WeaponsCode,
                        principalTable: "Weapons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatAmmunition_AmmunitionCode",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                column: "AmmunitionCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatEquipments_EquipmentCode",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                column: "EquipmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatExplosives_ExplosiveCode",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                column: "ExplosiveCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_SquadCode",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "SquadCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_SquadronCode",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "SquadronCode");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_TroopId",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatWeapon_WeaponsCode",
                table: "WarMaterialDeliveryCertificateFormatWeapon",
                column: "WeaponsCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatWeapon");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormats");
        }
    }
}
