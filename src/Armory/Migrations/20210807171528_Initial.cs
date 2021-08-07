using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ammunition",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ammunition", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Explosives",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explosives", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfProviders = table.Column<int>(type: "int", nullable: false),
                    ProviderCapacity = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Code);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ArmoryUserId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Squadrons",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squadrons", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Squadrons_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Squads",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SquadronCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squads", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Squads_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Squads_Squadrons_SquadronCode",
                        column: x => x.SquadronCode,
                        principalTable: "Squadrons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignedWeaponMagazineFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SquadCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Warehouse = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Troopers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecondLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SquadCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssignedWeaponMagazineFormatItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TroopId = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CartridgeOfLife = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VerifiedInPhysical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Novelty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Observations = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SquadCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TroopId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Warehouse = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    DocMovement = table.Column<int>(type: "int", nullable: false),
                    PhysicalLocation = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Others = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SquadronCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SquadCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TroopId = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    AmmunitionCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    ExplosiveCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                columns: table => new
                {
                    WarMaterialAndSpecialEquipmentAssignmentFormatId = table.Column<int>(type: "int", nullable: false),
                    WeaponCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons", x => new { x.WarMaterialAndSpecialEquipmentAssignmentFormatId, x.WeaponCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_WarMat~",
                        column: x => x.WarMaterialAndSpecialEquipmentAssignmentFormatId,
                        principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~",
                        column: x => x.WeaponCode,
                        principalTable: "Weapons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatAmmunition",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    AmmunitionCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatEquipments",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    EquipmentCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatExplosives",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    ExplosiveCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarMaterialDeliveryCertificateFormatWeapons",
                columns: table => new
                {
                    WarMaterialDeliveryCertificateFormatId = table.Column<int>(type: "int", nullable: false),
                    WeaponCode = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarMaterialDeliveryCertificateFormatWeapons", x => new { x.WarMaterialDeliveryCertificateFormatId, x.WeaponCode });
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatWeapons_WarMaterialDeliv~",
                        column: x => x.WarMaterialDeliveryCertificateFormatId,
                        principalTable: "WarMaterialDeliveryCertificateFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarMaterialDeliveryCertificateFormatWeapons_Weapons_WeaponCo~",
                        column: x => x.WeaponCode,
                        principalTable: "Weapons",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_RankId",
                table: "Degrees",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ArmoryUserId",
                table: "People",
                column: "ArmoryUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Squadrons_PersonId",
                table: "Squadrons",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_PersonId",
                table: "Squads",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Squads_SquadronCode",
                table: "Squads",
                column: "SquadronCode");

            migrationBuilder.CreateIndex(
                name: "IX_Troopers_DegreeId",
                table: "Troopers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Troopers_SquadCode",
                table: "Troopers",
                column: "SquadCode");

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
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                column: "WeaponCode");

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
                name: "IX_WarMaterialDeliveryCertificateFormatWeapons_WeaponCode",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                column: "WeaponCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormatWeapons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AssignedWeaponMagazineFormats");

            migrationBuilder.DropTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.DropTable(
                name: "Ammunition");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Explosives");

            migrationBuilder.DropTable(
                name: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Troopers");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Squads");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Squadrons");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
