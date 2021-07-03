using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class UpdateSquadronsRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squadrons_AspNetUsers_ArmoryUserId",
                table: "Squadrons");

            migrationBuilder.DropIndex(
                name: "IX_Squadrons_ArmoryUserId",
                table: "Squadrons");

            migrationBuilder.DropColumn(
                name: "ArmoryUserId",
                table: "Squadrons");

            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Squadrons",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Squadrons_PersonId",
                table: "Squadrons",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squadrons_People_PersonId",
                table: "Squadrons",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Squadrons_People_PersonId",
                table: "Squadrons");

            migrationBuilder.DropIndex(
                name: "IX_Squadrons_PersonId",
                table: "Squadrons");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Squadrons");

            migrationBuilder.AddColumn<string>(
                name: "ArmoryUserId",
                table: "Squadrons",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Squadrons_ArmoryUserId",
                table: "Squadrons",
                column: "ArmoryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Squadrons_AspNetUsers_ArmoryUserId",
                table: "Squadrons",
                column: "ArmoryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
