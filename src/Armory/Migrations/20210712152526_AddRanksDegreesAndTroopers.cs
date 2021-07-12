using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Armory.Migrations
{
    public partial class AddRanksDegreesAndTroopers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    RankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Degrees_Ranks_RankId",
                        column: x => x.RankId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Troopers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SecondName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SecondLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SquadCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troopers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Troopers_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Troopers_Squads_SquadCode",
                        column: x => x.SquadCode,
                        principalTable: "Squads",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_RankId",
                table: "Degrees",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Troopers_DegreeId",
                table: "Troopers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Troopers_SquadCode",
                table: "Troopers",
                column: "SquadCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Troopers");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Ranks");
        }
    }
}
