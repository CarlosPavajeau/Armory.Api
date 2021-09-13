using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class AddPersonDegree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "degree_id",
                table: "people",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "ix_people_degree_id",
                table: "people",
                column: "degree_id");

            migrationBuilder.AddForeignKey(
                name: "fk_people_degrees_degree_id",
                table: "people",
                column: "degree_id",
                principalTable: "degrees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_people_degrees_degree_id",
                table: "people");

            migrationBuilder.DropIndex(
                name: "ix_people_degree_id",
                table: "people");

            migrationBuilder.DropColumn(
                name: "degree_id",
                table: "people");
        }
    }
}
