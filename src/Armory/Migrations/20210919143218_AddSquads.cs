using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class AddSquads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "squad_code",
                table: "flights",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "squads",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_flights_squad_code",
                table: "flights",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_squads_person_id",
                table: "squads",
                column: "person_id");

            migrationBuilder.AddForeignKey(
                name: "fk_flights_squads_squad_code",
                table: "flights",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_flights_squads_squad_code",
                table: "flights");

            migrationBuilder.DropTable(
                name: "squads");

            migrationBuilder.DropIndex(
                name: "ix_flights_squad_code",
                table: "flights");

            migrationBuilder.DropColumn(
                name: "squad_code",
                table: "flights");
        }
    }
}
