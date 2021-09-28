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
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalized_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    concurrency_stamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalized_user_name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalized_email = table.Column<string>(type: "varchar(127)", maxLength: 127, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email_confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    password_hash = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    security_stamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    concurrency_stamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone_number_confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    access_failed_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ranks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ranks", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claim_type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claim_value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claim_type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claim_value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    provider_key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    provider_display_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    login_provider = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "degrees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rank_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_degrees", x => x.id);
                    table.ForeignKey(
                        name: "fk_degrees_ranks_rank_id",
                        column: x => x.rank_id,
                        principalTable: "ranks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    second_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    second_last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    armory_user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    degree_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                    table.ForeignKey(
                        name: "fk_people_degrees_degree_id",
                        column: x => x.degree_id,
                        principalTable: "degrees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_people_users_armory_user_id",
                        column: x => x.armory_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
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

            migrationBuilder.CreateTable(
                name: "flights",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    squad_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flights", x => x.code);
                    table.ForeignKey(
                        name: "fk_flights_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_flights_squads_squad_code",
                        column: x => x.squad_code,
                        principalTable: "squads",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ammunition",
                columns: table => new
                {
                    lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity_available = table.Column<int>(type: "int", nullable: false),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ammunition", x => x.lot);
                    table.ForeignKey(
                        name: "fk_ammunition_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "explosives",
                columns: table => new
                {
                    serial = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lot = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity_available = table.Column<int>(type: "int", nullable: false),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_explosives", x => x.serial);
                    table.ForeignKey(
                        name: "fk_explosives_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fireteams",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    person_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fireteams", x => x.code);
                    table.ForeignKey(
                        name: "fk_fireteams_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_fireteams_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "assigned_weapon_magazine_formats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    squad_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fireteam_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    warehouse = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    comments = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assigned_weapon_magazine_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_formats_fireteams_fireteam_code",
                        column: x => x.fireteam_code,
                        principalTable: "fireteams",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_formats_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                        column: x => x.squad_code,
                        principalTable: "squads",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "troopers",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    second_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    second_last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fireteam_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    degree_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_troopers", x => x.id);
                    table.ForeignKey(
                        name: "fk_troopers_degrees_degree_id",
                        column: x => x.degree_id,
                        principalTable: "degrees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_troopers_fireteams_fireteam_code",
                        column: x => x.fireteam_code,
                        principalTable: "fireteams",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "equipments",
                columns: table => new
                {
                    series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity_available = table.Column<int>(type: "int", nullable: false),
                    troop_id = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_equipments", x => x.series);
                    table.ForeignKey(
                        name: "fk_equipments_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_equipments_troopers_troop_id",
                        column: x => x.troop_id,
                        principalTable: "troopers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_and_special_equipment_assignment_formats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    squad_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fireteam_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    troop_id = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    warehouse = table.Column<int>(type: "int", nullable: false),
                    purpose = table.Column<int>(type: "int", nullable: false),
                    doc_movement = table.Column<int>(type: "int", nullable: false),
                    physical_location = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    others = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_and_special_equipment_assignment_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_formats_firete",
                        column: x => x.fireteam_code,
                        principalTable: "fireteams",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_formats_flight",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                        column: x => x.squad_code,
                        principalTable: "squads",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_formats_troope",
                        column: x => x.troop_id,
                        principalTable: "troopers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_delivery_certificate_formats",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    validity = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    place = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    squad_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fireteam_code = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    troop_id = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_delivery_certificate_formats", x => x.id);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_formats_fireteams_fireteam",
                        column: x => x.fireteam_code,
                        principalTable: "fireteams",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_formats_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                        column: x => x.squad_code,
                        principalTable: "squads",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_formats_troopers_troop_id",
                        column: x => x.troop_id,
                        principalTable: "troopers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "weapons",
                columns: table => new
                {
                    series = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    type = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    mark = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    model = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    caliber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    number_of_providers = table.Column<int>(type: "int", nullable: false),
                    provider_capacity = table.Column<int>(type: "int", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    troop_id = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    flight_code = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_weapons", x => x.series);
                    table.ForeignKey(
                        name: "fk_weapons_flights_flight_code",
                        column: x => x.flight_code,
                        principalTable: "flights",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_weapons_troopers_troop_id",
                        column: x => x.troop_id,
                        principalTable: "troopers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_and_special_equipment_assignment_format_ammunition",
                columns: table => new
                {
                    war_material_and_special_equipment_assignment_format_id = table.Column<int>(type: "int", nullable: false),
                    ammunition_lot = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_and_special_equipment_assignment_format_ammunit", x => new { x.war_material_and_special_equipment_assignment_format_id, x.ammunition_lot });
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_ammunit",
                        column: x => x.ammunition_lot,
                        principalTable: "ammunition",
                        principalColumn: "lot",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_ammunit1",
                        column: x => x.war_material_and_special_equipment_assignment_format_id,
                        principalTable: "war_material_and_special_equipment_assignment_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_and_special_equipment_assignment_format_equipments",
                columns: table => new
                {
                    war_material_and_special_equipment_assignment_format_id = table.Column<int>(type: "int", nullable: false),
                    equipment_series = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_and_special_equipment_assignment_format_equipme", x => new { x.war_material_and_special_equipment_assignment_format_id, x.equipment_series });
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_equipme",
                        column: x => x.equipment_series,
                        principalTable: "equipments",
                        principalColumn: "series",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_equipme1",
                        column: x => x.war_material_and_special_equipment_assignment_format_id,
                        principalTable: "war_material_and_special_equipment_assignment_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_and_special_equipment_assignment_format_explosives",
                columns: table => new
                {
                    war_material_and_special_equipment_assignment_format_id = table.Column<int>(type: "int", nullable: false),
                    explosive_serial = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_and_special_equipment_assignment_format_explosi", x => new { x.war_material_and_special_equipment_assignment_format_id, x.explosive_serial });
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_explosi",
                        column: x => x.explosive_serial,
                        principalTable: "explosives",
                        principalColumn: "serial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_explosi1",
                        column: x => x.war_material_and_special_equipment_assignment_format_id,
                        principalTable: "war_material_and_special_equipment_assignment_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_delivery_certificate_format_ammunition",
                columns: table => new
                {
                    war_material_delivery_certificate_format_id = table.Column<int>(type: "int", nullable: false),
                    ammunition_lot = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_delivery_certificate_format_ammunition", x => new { x.war_material_delivery_certificate_format_id, x.ammunition_lot });
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_ammunition_ammuniti",
                        column: x => x.ammunition_lot,
                        principalTable: "ammunition",
                        principalColumn: "lot",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_ammunition_war_mate",
                        column: x => x.war_material_delivery_certificate_format_id,
                        principalTable: "war_material_delivery_certificate_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_delivery_certificate_format_equipments",
                columns: table => new
                {
                    war_material_delivery_certificate_format_id = table.Column<int>(type: "int", nullable: false),
                    equipment_series = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_delivery_certificate_format_equipments", x => new { x.war_material_delivery_certificate_format_id, x.equipment_series });
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_equipments_equipmen",
                        column: x => x.equipment_series,
                        principalTable: "equipments",
                        principalColumn: "series",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_equipments_war_mate",
                        column: x => x.war_material_delivery_certificate_format_id,
                        principalTable: "war_material_delivery_certificate_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_delivery_certificate_format_explosives",
                columns: table => new
                {
                    war_material_delivery_certificate_format_id = table.Column<int>(type: "int", nullable: false),
                    explosive_serial = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_delivery_certificate_format_explosives", x => new { x.war_material_delivery_certificate_format_id, x.explosive_serial });
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_explosives_explosiv",
                        column: x => x.explosive_serial,
                        principalTable: "explosives",
                        principalColumn: "serial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_explosives_war_mate",
                        column: x => x.war_material_delivery_certificate_format_id,
                        principalTable: "war_material_delivery_certificate_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "assigned_weapon_magazine_format_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    troop_id = table.Column<string>(type: "varchar(10)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    weapon_series = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    safety_cartridge = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    verified_in_physical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    novelty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ammunition_quantity = table.Column<int>(type: "int", nullable: false),
                    ammunition_lot = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observations = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    assigned_weapon_magazine_format_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assigned_weapon_magazine_format_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_format_items_assigned_weapon_magazi",
                        column: x => x.assigned_weapon_magazine_format_id,
                        principalTable: "assigned_weapon_magazine_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_format_items_troopers_troop_id",
                        column: x => x.troop_id,
                        principalTable: "troopers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_series",
                        column: x => x.weapon_series,
                        principalTable: "weapons",
                        principalColumn: "series",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_and_special_equipment_assignment_format_weapons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    war_material_and_special_equipment_assignment_format_id = table.Column<int>(type: "int", nullable: false),
                    weapon_series = table.Column<string>(type: "varchar(256)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_and_special_equipment_assignment_format_weapons", x => x.id);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_weapons",
                        column: x => x.war_material_and_special_equipment_assignment_format_id,
                        principalTable: "war_material_and_special_equipment_assignment_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_and_special_equipment_assignment_format_weapons1",
                        column: x => x.weapon_series,
                        principalTable: "weapons",
                        principalColumn: "series",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "war_material_delivery_certificate_format_weapons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    war_material_delivery_certificate_format_id = table.Column<int>(type: "int", nullable: false),
                    weapon_series = table.Column<string>(type: "varchar(256)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_war_material_delivery_certificate_format_weapons", x => x.id);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_weapons_war_materia",
                        column: x => x.war_material_delivery_certificate_format_id,
                        principalTable: "war_material_delivery_certificate_formats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_war_material_delivery_certificate_format_weapons_weapons_wea",
                        column: x => x.weapon_series,
                        principalTable: "weapons",
                        principalColumn: "series",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_ammunition_flight_code",
                table: "ammunition",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_email",
                table: "AspNetUsers",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_users_phone_number",
                table: "AspNetUsers",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_format_items_assigned_weapon_magazi",
                table: "assigned_weapon_magazine_format_items",
                column: "assigned_weapon_magazine_format_id");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_format_items_troop_id",
                table: "assigned_weapon_magazine_format_items",
                column: "troop_id");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_format_items_weapon_series",
                table: "assigned_weapon_magazine_format_items",
                column: "weapon_series");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_formats_fireteam_code",
                table: "assigned_weapon_magazine_formats",
                column: "fireteam_code");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_formats_flight_code",
                table: "assigned_weapon_magazine_formats",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_assigned_weapon_magazine_formats_squad_code",
                table: "assigned_weapon_magazine_formats",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_degrees_rank_id",
                table: "degrees",
                column: "rank_id");

            migrationBuilder.CreateIndex(
                name: "ix_equipments_flight_code",
                table: "equipments",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_equipments_troop_id",
                table: "equipments",
                column: "troop_id");

            migrationBuilder.CreateIndex(
                name: "ix_explosives_flight_code",
                table: "explosives",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_fireteams_flight_code",
                table: "fireteams",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_fireteams_person_id",
                table: "fireteams",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_flights_person_id",
                table: "flights",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_flights_squad_code",
                table: "flights",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_people_armory_user_id",
                table: "people",
                column: "armory_user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_people_degree_id",
                table: "people",
                column: "degree_id");

            migrationBuilder.CreateIndex(
                name: "ix_squads_person_id",
                table: "squads",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "ix_troopers_degree_id",
                table: "troopers",
                column: "degree_id");

            migrationBuilder.CreateIndex(
                name: "ix_troopers_fireteam_code",
                table: "troopers",
                column: "fireteam_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_ammunit",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                column: "ammunition_lot");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_equipme",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                column: "equipment_series");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_explosi",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                column: "explosive_serial");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_weapons",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                column: "weapon_series");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_weapons1",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                columns: new[] { "war_material_and_special_equipment_assignment_format_id", "weapon_series" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_firete",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "fireteam_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_flight",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squad_",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_troop_",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "troop_id");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_format_ammunition_ammuniti",
                table: "war_material_delivery_certificate_format_ammunition",
                column: "ammunition_lot");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_format_equipments_equipmen",
                table: "war_material_delivery_certificate_format_equipments",
                column: "equipment_series");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_format_explosives_explosiv",
                table: "war_material_delivery_certificate_format_explosives",
                column: "explosive_serial");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_format_weapons_war_materia",
                table: "war_material_delivery_certificate_format_weapons",
                columns: new[] { "war_material_delivery_certificate_format_id", "weapon_series" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_format_weapons_weapon_seri",
                table: "war_material_delivery_certificate_format_weapons",
                column: "weapon_series");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_formats_fireteam_code",
                table: "war_material_delivery_certificate_formats",
                column: "fireteam_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_formats_flight_code",
                table: "war_material_delivery_certificate_formats",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_formats_squad_code",
                table: "war_material_delivery_certificate_formats",
                column: "squad_code");

            migrationBuilder.CreateIndex(
                name: "ix_war_material_delivery_certificate_formats_troop_id",
                table: "war_material_delivery_certificate_formats",
                column: "troop_id");

            migrationBuilder.CreateIndex(
                name: "ix_weapons_flight_code",
                table: "weapons",
                column: "flight_code");

            migrationBuilder.CreateIndex(
                name: "ix_weapons_troop_id",
                table: "weapons",
                column: "troop_id");
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
                name: "assigned_weapon_magazine_format_items");

            migrationBuilder.DropTable(
                name: "war_material_and_special_equipment_assignment_format_ammunition");

            migrationBuilder.DropTable(
                name: "war_material_and_special_equipment_assignment_format_equipments");

            migrationBuilder.DropTable(
                name: "war_material_and_special_equipment_assignment_format_explosives");

            migrationBuilder.DropTable(
                name: "war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.DropTable(
                name: "war_material_delivery_certificate_format_ammunition");

            migrationBuilder.DropTable(
                name: "war_material_delivery_certificate_format_equipments");

            migrationBuilder.DropTable(
                name: "war_material_delivery_certificate_format_explosives");

            migrationBuilder.DropTable(
                name: "war_material_delivery_certificate_format_weapons");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "assigned_weapon_magazine_formats");

            migrationBuilder.DropTable(
                name: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropTable(
                name: "ammunition");

            migrationBuilder.DropTable(
                name: "equipments");

            migrationBuilder.DropTable(
                name: "explosives");

            migrationBuilder.DropTable(
                name: "war_material_delivery_certificate_formats");

            migrationBuilder.DropTable(
                name: "weapons");

            migrationBuilder.DropTable(
                name: "troopers");

            migrationBuilder.DropTable(
                name: "fireteams");

            migrationBuilder.DropTable(
                name: "flights");

            migrationBuilder.DropTable(
                name: "squads");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "degrees");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ranks");
        }
    }
}
