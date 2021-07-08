using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class AddWeapons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Model = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    NumberOfProviders = table.Column<int>(type: "int", nullable: false),
                    ProviderCapacity = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
