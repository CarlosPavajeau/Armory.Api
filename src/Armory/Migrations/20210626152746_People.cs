using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class People : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SecondName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SecondLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ArmoryUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_AspNetUsers_ArmoryUserId",
                        column: x => x.ArmoryUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_ArmoryUserId",
                table: "People",
                column: "ArmoryUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
