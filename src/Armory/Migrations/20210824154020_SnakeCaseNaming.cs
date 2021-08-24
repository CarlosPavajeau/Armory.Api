using Microsoft.EntityFrameworkCore.Migrations;

namespace Armory.Migrations
{
    public partial class SnakeCaseNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Troopers_TroopId",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Weapons_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormats_Squadrons_SquadronCode",
                table: "AssignedWeaponMagazineFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignedWeaponMagazineFormats_Squads_SquadCode",
                table: "AssignedWeaponMagazineFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Ranks_RankId",
                table: "Degrees");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AspNetUsers_ArmoryUserId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Squadrons_People_PersonId",
                table: "Squadrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Squads_People_PersonId",
                table: "Squads");

            migrationBuilder.DropForeignKey(
                name: "FK_Squads_Squadrons_SquadronCode",
                table: "Squads");

            migrationBuilder.DropForeignKey(
                name: "FK_Troopers_Degrees_DegreeId",
                table: "Troopers");

            migrationBuilder.DropForeignKey(
                name: "FK_Troopers_Squads_SquadCode",
                table: "Troopers");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_Amm~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squadrons_Sq~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squads_Squad~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Troopers_Tro~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_WarMat~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_Ammunition_Am~",
                table: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatEquipments_Equipments_Eq~",
                table: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatEquipments_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatExplosives_Explosives_Ex~",
                table: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatExplosives_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Squadrons_SquadronCode",
                table: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Squads_SquadCode",
                table: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Troopers_TroopId",
                table: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatWeapons_WarMaterialDeliv~",
                table: "WarMaterialDeliveryCertificateFormatWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatWeapons_Weapons_WeaponCo~",
                table: "WarMaterialDeliveryCertificateFormatWeapons");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Troopers_TroopId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Troopers",
                table: "Troopers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squads",
                table: "Squads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Squadrons",
                table: "Squadrons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Explosives",
                table: "Explosives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ammunition",
                table: "Ammunition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatWeapons",
                table: "WarMaterialDeliveryCertificateFormatWeapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormats",
                table: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatExplosives",
                table: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatEquipments",
                table: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatAmmunition",
                table: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormats",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedWeaponMagazineFormats",
                table: "AssignedWeaponMagazineFormats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignedWeaponMagazineFormatItems",
                table: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "weapons");

            migrationBuilder.RenameTable(
                name: "Troopers",
                newName: "troopers");

            migrationBuilder.RenameTable(
                name: "Squads",
                newName: "squads");

            migrationBuilder.RenameTable(
                name: "Squadrons",
                newName: "squadrons");

            migrationBuilder.RenameTable(
                name: "Ranks",
                newName: "ranks");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "people");

            migrationBuilder.RenameTable(
                name: "Explosives",
                newName: "explosives");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "equipments");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "degrees");

            migrationBuilder.RenameTable(
                name: "Ammunition",
                newName: "ammunition");

            migrationBuilder.RenameTable(
                name: "WarMaterialDeliveryCertificateFormatWeapons",
                newName: "war_material_delivery_certificate_format_weapons");

            migrationBuilder.RenameTable(
                name: "WarMaterialDeliveryCertificateFormats",
                newName: "war_material_delivery_certificate_formats");

            migrationBuilder.RenameTable(
                name: "WarMaterialDeliveryCertificateFormatExplosives",
                newName: "war_material_delivery_certificate_format_explosives");

            migrationBuilder.RenameTable(
                name: "WarMaterialDeliveryCertificateFormatEquipments",
                newName: "war_material_delivery_certificate_format_equipments");

            migrationBuilder.RenameTable(
                name: "WarMaterialDeliveryCertificateFormatAmmunition",
                newName: "war_material_delivery_certificate_format_ammunition");

            migrationBuilder.RenameTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                newName: "war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.RenameTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.RenameTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                newName: "war_material_and_special_equipment_assignment_format_explosives");

            migrationBuilder.RenameTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                newName: "war_material_and_special_equipment_assignment_format_equipments");

            migrationBuilder.RenameTable(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                newName: "war_material_and_special_equipment_assignment_format_ammunition");

            migrationBuilder.RenameTable(
                name: "AssignedWeaponMagazineFormats",
                newName: "assigned_weapon_magazine_formats");

            migrationBuilder.RenameTable(
                name: "AssignedWeaponMagazineFormatItems",
                newName: "assigned_weapon_magazine_format_items");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "weapons",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "weapons",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "weapons",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "weapons",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "weapons",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "Lot",
                table: "weapons",
                newName: "lot");

            migrationBuilder.RenameColumn(
                name: "Caliber",
                table: "weapons",
                newName: "caliber");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "weapons",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "TroopId",
                table: "weapons",
                newName: "troop_id");

            migrationBuilder.RenameColumn(
                name: "ProviderCapacity",
                table: "weapons",
                newName: "provider_capacity");

            migrationBuilder.RenameColumn(
                name: "NumberOfProviders",
                table: "weapons",
                newName: "number_of_providers");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_Series",
                table: "weapons",
                newName: "ix_weapons_series");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_Lot",
                table: "weapons",
                newName: "ix_weapons_lot");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_TroopId",
                table: "weapons",
                newName: "ix_weapons_troop_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "troopers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SquadCode",
                table: "troopers",
                newName: "squad_code");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "troopers",
                newName: "second_name");

            migrationBuilder.RenameColumn(
                name: "SecondLastName",
                table: "troopers",
                newName: "second_last_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "troopers",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "troopers",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "DegreeId",
                table: "troopers",
                newName: "degree_id");

            migrationBuilder.RenameIndex(
                name: "IX_Troopers_SquadCode",
                table: "troopers",
                newName: "ix_troopers_squad_code");

            migrationBuilder.RenameIndex(
                name: "IX_Troopers_DegreeId",
                table: "troopers",
                newName: "ix_troopers_degree_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "squads",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "squads",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "SquadronCode",
                table: "squads",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "squads",
                newName: "person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Squads_SquadronCode",
                table: "squads",
                newName: "ix_squads_squadron_code");

            migrationBuilder.RenameIndex(
                name: "IX_Squads_PersonId",
                table: "squads",
                newName: "ix_squads_person_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "squadrons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "squadrons",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "squadrons",
                newName: "person_id");

            migrationBuilder.RenameIndex(
                name: "IX_Squadrons_PersonId",
                table: "squadrons",
                newName: "ix_squadrons_person_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ranks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ranks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "people",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "people",
                newName: "second_name");

            migrationBuilder.RenameColumn(
                name: "SecondLastName",
                table: "people",
                newName: "second_last_name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "people",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "people",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "ArmoryUserId",
                table: "people",
                newName: "armory_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_People_ArmoryUserId",
                table: "people",
                newName: "ix_people_armory_user_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "explosives",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "explosives",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "explosives",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "Lot",
                table: "explosives",
                newName: "lot");

            migrationBuilder.RenameColumn(
                name: "Caliber",
                table: "explosives",
                newName: "caliber");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "explosives",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "QuantityAvailable",
                table: "explosives",
                newName: "quantity_available");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "equipments",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "equipments",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "equipments",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "equipments",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "QuantityAvailable",
                table: "equipments",
                newName: "quantity_available");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "degrees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "degrees",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RankId",
                table: "degrees",
                newName: "rank_id");

            migrationBuilder.RenameIndex(
                name: "IX_Degrees_RankId",
                table: "degrees",
                newName: "ix_degrees_rank_id");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "AspNetUserTokens",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUserTokens",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserTokens",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AspNetUsers",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUsers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AspNetUsers",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                newName: "two_factor_enabled");

            migrationBuilder.RenameColumn(
                name: "SecurityStamp",
                table: "AspNetUsers",
                newName: "security_stamp");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                newName: "phone_number_confirmed");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AspNetUsers",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "AspNetUsers",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                newName: "normalized_email");

            migrationBuilder.RenameColumn(
                name: "LockoutEnd",
                table: "AspNetUsers",
                newName: "lockout_end");

            migrationBuilder.RenameColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                newName: "lockout_enabled");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                newName: "access_failed_count");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                newName: "ix_asp_net_users_phone_number");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                newName: "ix_asp_net_users_email");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetUserRoles",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserRoles",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "ix_asp_net_user_roles_role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserLogins",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "AspNetUserLogins",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "ix_asp_net_user_logins_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetUserClaims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUserClaims",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetUserClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetUserClaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "ix_asp_net_user_claims_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetRoles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "AspNetRoles",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "AspNetRoles",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AspNetRoleClaims",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "AspNetRoleClaims",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "AspNetRoleClaims",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "AspNetRoleClaims",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "ix_asp_net_role_claims_role_id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ammunition",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Series",
                table: "ammunition",
                newName: "series");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "ammunition",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "Lot",
                table: "ammunition",
                newName: "lot");

            migrationBuilder.RenameColumn(
                name: "Caliber",
                table: "ammunition",
                newName: "caliber");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ammunition",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "QuantityAvailable",
                table: "ammunition",
                newName: "quantity_available");

            migrationBuilder.RenameColumn(
                name: "WeaponCode",
                table: "war_material_delivery_certificate_format_weapons",
                newName: "weapon_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialDeliveryCertificateFormatId",
                table: "war_material_delivery_certificate_format_weapons",
                newName: "war_material_delivery_certificate_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatWeapons_WeaponCode",
                table: "war_material_delivery_certificate_format_weapons",
                newName: "ix_war_material_delivery_certificate_format_weapons_weapon_code");

            migrationBuilder.RenameColumn(
                name: "Validity",
                table: "war_material_delivery_certificate_formats",
                newName: "validity");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "war_material_delivery_certificate_formats",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "war_material_delivery_certificate_formats",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "war_material_delivery_certificate_formats",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "war_material_delivery_certificate_formats",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TroopId",
                table: "war_material_delivery_certificate_formats",
                newName: "troop_id");

            migrationBuilder.RenameColumn(
                name: "SquadronCode",
                table: "war_material_delivery_certificate_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "SquadCode",
                table: "war_material_delivery_certificate_formats",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_TroopId",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_troop_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_SquadronCode",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_squadron_code");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormats_SquadCode",
                table: "war_material_delivery_certificate_formats",
                newName: "ix_war_material_delivery_certificate_formats_squad_code");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_delivery_certificate_format_explosives",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ExplosiveCode",
                table: "war_material_delivery_certificate_format_explosives",
                newName: "explosive_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialDeliveryCertificateFormatId",
                table: "war_material_delivery_certificate_format_explosives",
                newName: "war_material_delivery_certificate_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatExplosives_ExplosiveCode",
                table: "war_material_delivery_certificate_format_explosives",
                newName: "ix_war_material_delivery_certificate_format_explosives_explosiv");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "EquipmentCode",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "equipment_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialDeliveryCertificateFormatId",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "war_material_delivery_certificate_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatEquipments_EquipmentCode",
                table: "war_material_delivery_certificate_format_equipments",
                newName: "ix_war_material_delivery_certificate_format_equipments_equipmen");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_delivery_certificate_format_ammunition",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "AmmunitionCode",
                table: "war_material_delivery_certificate_format_ammunition",
                newName: "ammunition_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialDeliveryCertificateFormatId",
                table: "war_material_delivery_certificate_format_ammunition",
                newName: "war_material_delivery_certificate_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialDeliveryCertificateFormatAmmunition_AmmunitionCode",
                table: "war_material_delivery_certificate_format_ammunition",
                newName: "ix_war_material_delivery_certificate_format_ammunition_ammuniti");

            migrationBuilder.RenameColumn(
                name: "WeaponCode",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "weapon_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "war_material_and_special_equipment_assignment_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "ix_war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "warehouse");

            migrationBuilder.RenameColumn(
                name: "Validity",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "validity");

            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "purpose");

            migrationBuilder.RenameColumn(
                name: "Place",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "place");

            migrationBuilder.RenameColumn(
                name: "Others",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "others");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TroopId",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "troop_id");

            migrationBuilder.RenameColumn(
                name: "SquadronCode",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "SquadCode",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "squad_code");

            migrationBuilder.RenameColumn(
                name: "PhysicalLocation",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "physical_location");

            migrationBuilder.RenameColumn(
                name: "DocMovement",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "doc_movement");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_TroopId",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_troop_");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadronCode",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_squadr");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadCode",
                table: "war_material_and_special_equipment_assignment_formats",
                newName: "ix_war_material_and_special_equipment_assignment_formats_squad_");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ExplosiveCode",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                newName: "explosive_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                newName: "war_material_and_special_equipment_assignment_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                newName: "ix_war_material_and_special_equipment_assignment_format_explosi");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "EquipmentCode",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "equipment_code");

            migrationBuilder.RenameColumn(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "war_material_and_special_equipment_assignment_format_id");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "ix_war_material_and_special_equipment_assignment_format_equipme");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                newName: "war_material_and_special_equipment_assignment_format_id");

            migrationBuilder.RenameColumn(
                name: "AmmunitionCode",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                newName: "ammunition_code");

            migrationBuilder.RenameIndex(
                name: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                newName: "ix_war_material_and_special_equipment_assignment_format_ammunit");

            migrationBuilder.RenameColumn(
                name: "Warehouse",
                table: "assigned_weapon_magazine_formats",
                newName: "warehouse");

            migrationBuilder.RenameColumn(
                name: "Validity",
                table: "assigned_weapon_magazine_formats",
                newName: "validity");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "assigned_weapon_magazine_formats",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "assigned_weapon_magazine_formats",
                newName: "comments");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "assigned_weapon_magazine_formats",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "assigned_weapon_magazine_formats",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "SquadronCode",
                table: "assigned_weapon_magazine_formats",
                newName: "squadron_code");

            migrationBuilder.RenameColumn(
                name: "SquadCode",
                table: "assigned_weapon_magazine_formats",
                newName: "squad_code");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedWeaponMagazineFormats_SquadronCode",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_squadron_code");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedWeaponMagazineFormats_SquadCode",
                table: "assigned_weapon_magazine_formats",
                newName: "ix_assigned_weapon_magazine_formats_squad_code");

            migrationBuilder.RenameColumn(
                name: "Observations",
                table: "assigned_weapon_magazine_format_items",
                newName: "observations");

            migrationBuilder.RenameColumn(
                name: "Novelty",
                table: "assigned_weapon_magazine_format_items",
                newName: "novelty");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "assigned_weapon_magazine_format_items",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WeaponCode",
                table: "assigned_weapon_magazine_format_items",
                newName: "weapon_code");

            migrationBuilder.RenameColumn(
                name: "VerifiedInPhysical",
                table: "assigned_weapon_magazine_format_items",
                newName: "verified_in_physical");

            migrationBuilder.RenameColumn(
                name: "TroopId",
                table: "assigned_weapon_magazine_format_items",
                newName: "troop_id");

            migrationBuilder.RenameColumn(
                name: "CartridgeOfLife",
                table: "assigned_weapon_magazine_format_items",
                newName: "cartridge_of_life");

            migrationBuilder.RenameColumn(
                name: "AssignedWeaponMagazineFormatId",
                table: "assigned_weapon_magazine_format_items",
                newName: "assigned_weapon_magazine_format_id");

            migrationBuilder.RenameColumn(
                name: "AmmunitionQuantity",
                table: "assigned_weapon_magazine_format_items",
                newName: "ammunition_quantity");

            migrationBuilder.RenameColumn(
                name: "AmmunitionLot",
                table: "assigned_weapon_magazine_format_items",
                newName: "ammunition_lot");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_WeaponCode",
                table: "assigned_weapon_magazine_format_items",
                newName: "ix_assigned_weapon_magazine_format_items_weapon_code");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_TroopId",
                table: "assigned_weapon_magazine_format_items",
                newName: "ix_assigned_weapon_magazine_format_items_troop_id");

            migrationBuilder.RenameIndex(
                name: "IX_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~",
                table: "assigned_weapon_magazine_format_items",
                newName: "ix_assigned_weapon_magazine_format_items_assigned_weapon_magazi");

            migrationBuilder.AddPrimaryKey(
                name: "pk_weapons",
                table: "weapons",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_troopers",
                table: "troopers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_squads",
                table: "squads",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_squadrons",
                table: "squadrons",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_ranks",
                table: "ranks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_people",
                table: "people",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_explosives",
                table: "explosives",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_equipments",
                table: "equipments",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_degrees",
                table: "degrees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_tokens",
                table: "AspNetUserTokens",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_users",
                table: "AspNetUsers",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_roles",
                table: "AspNetUserRoles",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_logins",
                table: "AspNetUserLogins",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_user_claims",
                table: "AspNetUserClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_roles",
                table: "AspNetRoles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_role_claims",
                table: "AspNetRoleClaims",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_ammunition",
                table: "ammunition",
                column: "code");

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_weapons",
                table: "war_material_delivery_certificate_format_weapons",
                columns: new[] { "war_material_delivery_certificate_format_id", "weapon_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_delivery_certificate_formats",
                table: "war_material_delivery_certificate_formats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_explosives",
                table: "war_material_delivery_certificate_format_explosives",
                columns: new[] { "war_material_delivery_certificate_format_id", "explosive_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_equipments",
                table: "war_material_delivery_certificate_format_equipments",
                columns: new[] { "war_material_delivery_certificate_format_id", "equipment_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_ammunition",
                table: "war_material_delivery_certificate_format_ammunition",
                columns: new[] { "war_material_delivery_certificate_format_id", "ammunition_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_weapons",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                columns: new[] { "war_material_and_special_equipment_assignment_format_id", "weapon_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_formats",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_explosi",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                columns: new[] { "war_material_and_special_equipment_assignment_format_id", "explosive_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_equipme",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                columns: new[] { "war_material_and_special_equipment_assignment_format_id", "equipment_code" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_ammunit",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                columns: new[] { "ammunition_code", "war_material_and_special_equipment_assignment_format_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_assigned_weapon_magazine_formats",
                table: "assigned_weapon_magazine_formats",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_assigned_weapon_magazine_format_items",
                table: "assigned_weapon_magazine_format_items",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                table: "AspNetRoleClaims",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                table: "AspNetUserClaims",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                table: "AspNetUserLogins",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id",
                principalTable: "AspNetRoles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                table: "AspNetUserRoles",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                table: "AspNetUserTokens",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_assigned_weapon_magazi",
                table: "assigned_weapon_magazine_format_items",
                column: "assigned_weapon_magazine_format_id",
                principalTable: "assigned_weapon_magazine_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_troopers_troop_id",
                table: "assigned_weapon_magazine_format_items",
                column: "troop_id",
                principalTable: "troopers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_code",
                table: "assigned_weapon_magazine_format_items",
                column: "weapon_code",
                principalTable: "weapons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squadrons_squadron_code",
                table: "assigned_weapon_magazine_formats",
                column: "squadron_code",
                principalTable: "squadrons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_degrees_ranks_rank_id",
                table: "degrees",
                column: "rank_id",
                principalTable: "ranks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_people_users_armory_user_id",
                table: "people",
                column: "armory_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_squadrons_people_person_id",
                table: "squadrons",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_squads_people_person_id",
                table: "squads",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_squads_squadrons_squadron_code",
                table: "squads",
                column: "squadron_code",
                principalTable: "squadrons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_troopers_degrees_degree_id",
                table: "troopers",
                column: "degree_id",
                principalTable: "degrees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_troopers_squads_squad_code",
                table: "troopers",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_ammunit",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                column: "ammunition_code",
                principalTable: "ammunition",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_ammunit1",
                table: "war_material_and_special_equipment_assignment_format_ammunition",
                column: "war_material_and_special_equipment_assignment_format_id",
                principalTable: "war_material_and_special_equipment_assignment_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_equipme",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                column: "equipment_code",
                principalTable: "equipments",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_equipme1",
                table: "war_material_and_special_equipment_assignment_format_equipments",
                column: "war_material_and_special_equipment_assignment_format_id",
                principalTable: "war_material_and_special_equipment_assignment_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_explosi",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                column: "explosive_code",
                principalTable: "explosives",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_explosi1",
                table: "war_material_and_special_equipment_assignment_format_explosives",
                column: "war_material_and_special_equipment_assignment_format_id",
                principalTable: "war_material_and_special_equipment_assignment_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_weapons",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                column: "war_material_and_special_equipment_assignment_format_id",
                principalTable: "war_material_and_special_equipment_assignment_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_weapons1",
                table: "war_material_and_special_equipment_assignment_format_weapons",
                column: "weapon_code",
                principalTable: "weapons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squadr",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squadron_code",
                principalTable: "squadrons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_troope",
                table: "war_material_and_special_equipment_assignment_formats",
                column: "troop_id",
                principalTable: "troopers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_ammunition_ammuniti",
                table: "war_material_delivery_certificate_format_ammunition",
                column: "ammunition_code",
                principalTable: "ammunition",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_ammunition_war_mate",
                table: "war_material_delivery_certificate_format_ammunition",
                column: "war_material_delivery_certificate_format_id",
                principalTable: "war_material_delivery_certificate_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_equipments_equipmen",
                table: "war_material_delivery_certificate_format_equipments",
                column: "equipment_code",
                principalTable: "equipments",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_equipments_war_mate",
                table: "war_material_delivery_certificate_format_equipments",
                column: "war_material_delivery_certificate_format_id",
                principalTable: "war_material_delivery_certificate_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_explosives_explosiv",
                table: "war_material_delivery_certificate_format_explosives",
                column: "explosive_code",
                principalTable: "explosives",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_explosives_war_mate",
                table: "war_material_delivery_certificate_format_explosives",
                column: "war_material_delivery_certificate_format_id",
                principalTable: "war_material_delivery_certificate_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_weapons_war_materia",
                table: "war_material_delivery_certificate_format_weapons",
                column: "war_material_delivery_certificate_format_id",
                principalTable: "war_material_delivery_certificate_formats",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_format_weapons_weapons_wea",
                table: "war_material_delivery_certificate_format_weapons",
                column: "weapon_code",
                principalTable: "weapons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squadrons_squadron",
                table: "war_material_delivery_certificate_formats",
                column: "squadron_code",
                principalTable: "squadrons",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                table: "war_material_delivery_certificate_formats",
                column: "squad_code",
                principalTable: "squads",
                principalColumn: "code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_war_material_delivery_certificate_formats_troopers_troop_id",
                table: "war_material_delivery_certificate_formats",
                column: "troop_id",
                principalTable: "troopers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_weapons_troopers_troop_id",
                table: "weapons",
                column: "troop_id",
                principalTable: "troopers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_claims_asp_net_users_user_id",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_logins_asp_net_users_user_id",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_roles_asp_net_users_user_id",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_assigned_weapon_magazi",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_troopers_troop_id",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_format_items_weapons_weapon_code",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squadrons_squadron_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_assigned_weapon_magazine_formats_squads_squad_code",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_degrees_ranks_rank_id",
                table: "degrees");

            migrationBuilder.DropForeignKey(
                name: "fk_people_users_armory_user_id",
                table: "people");

            migrationBuilder.DropForeignKey(
                name: "fk_squadrons_people_person_id",
                table: "squadrons");

            migrationBuilder.DropForeignKey(
                name: "fk_squads_people_person_id",
                table: "squads");

            migrationBuilder.DropForeignKey(
                name: "fk_squads_squadrons_squadron_code",
                table: "squads");

            migrationBuilder.DropForeignKey(
                name: "fk_troopers_degrees_degree_id",
                table: "troopers");

            migrationBuilder.DropForeignKey(
                name: "fk_troopers_squads_squad_code",
                table: "troopers");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_ammunit",
                table: "war_material_and_special_equipment_assignment_format_ammunition");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_ammunit1",
                table: "war_material_and_special_equipment_assignment_format_ammunition");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_equipme",
                table: "war_material_and_special_equipment_assignment_format_equipments");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_equipme1",
                table: "war_material_and_special_equipment_assignment_format_equipments");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_explosi",
                table: "war_material_and_special_equipment_assignment_format_explosives");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_explosi1",
                table: "war_material_and_special_equipment_assignment_format_explosives");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_weapons",
                table: "war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_format_weapons1",
                table: "war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squadr",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_squads",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_and_special_equipment_assignment_formats_troope",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_ammunition_ammuniti",
                table: "war_material_delivery_certificate_format_ammunition");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_ammunition_war_mate",
                table: "war_material_delivery_certificate_format_ammunition");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_equipments_equipmen",
                table: "war_material_delivery_certificate_format_equipments");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_equipments_war_mate",
                table: "war_material_delivery_certificate_format_equipments");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_explosives_explosiv",
                table: "war_material_delivery_certificate_format_explosives");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_explosives_war_mate",
                table: "war_material_delivery_certificate_format_explosives");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_weapons_war_materia",
                table: "war_material_delivery_certificate_format_weapons");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_format_weapons_weapons_wea",
                table: "war_material_delivery_certificate_format_weapons");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squadrons_squadron",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_squads_squad_code",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_war_material_delivery_certificate_formats_troopers_troop_id",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropForeignKey(
                name: "fk_weapons_troopers_troop_id",
                table: "weapons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_weapons",
                table: "weapons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_troopers",
                table: "troopers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_squads",
                table: "squads");

            migrationBuilder.DropPrimaryKey(
                name: "pk_squadrons",
                table: "squadrons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_ranks",
                table: "ranks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_people",
                table: "people");

            migrationBuilder.DropPrimaryKey(
                name: "pk_explosives",
                table: "explosives");

            migrationBuilder.DropPrimaryKey(
                name: "pk_equipments",
                table: "equipments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_degrees",
                table: "degrees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_tokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_users",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_roles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_logins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_user_claims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_roles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_role_claims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "pk_ammunition",
                table: "ammunition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_delivery_certificate_formats",
                table: "war_material_delivery_certificate_formats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_weapons",
                table: "war_material_delivery_certificate_format_weapons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_explosives",
                table: "war_material_delivery_certificate_format_explosives");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_equipments",
                table: "war_material_delivery_certificate_format_equipments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_delivery_certificate_format_ammunition",
                table: "war_material_delivery_certificate_format_ammunition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_formats",
                table: "war_material_and_special_equipment_assignment_formats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_weapons",
                table: "war_material_and_special_equipment_assignment_format_weapons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_explosi",
                table: "war_material_and_special_equipment_assignment_format_explosives");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_equipme",
                table: "war_material_and_special_equipment_assignment_format_equipments");

            migrationBuilder.DropPrimaryKey(
                name: "pk_war_material_and_special_equipment_assignment_format_ammunit",
                table: "war_material_and_special_equipment_assignment_format_ammunition");

            migrationBuilder.DropPrimaryKey(
                name: "pk_assigned_weapon_magazine_formats",
                table: "assigned_weapon_magazine_formats");

            migrationBuilder.DropPrimaryKey(
                name: "pk_assigned_weapon_magazine_format_items",
                table: "assigned_weapon_magazine_format_items");

            migrationBuilder.RenameTable(
                name: "weapons",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "troopers",
                newName: "Troopers");

            migrationBuilder.RenameTable(
                name: "squads",
                newName: "Squads");

            migrationBuilder.RenameTable(
                name: "squadrons",
                newName: "Squadrons");

            migrationBuilder.RenameTable(
                name: "ranks",
                newName: "Ranks");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "explosives",
                newName: "Explosives");

            migrationBuilder.RenameTable(
                name: "equipments",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "degrees",
                newName: "Degrees");

            migrationBuilder.RenameTable(
                name: "ammunition",
                newName: "Ammunition");

            migrationBuilder.RenameTable(
                name: "war_material_delivery_certificate_formats",
                newName: "WarMaterialDeliveryCertificateFormats");

            migrationBuilder.RenameTable(
                name: "war_material_delivery_certificate_format_weapons",
                newName: "WarMaterialDeliveryCertificateFormatWeapons");

            migrationBuilder.RenameTable(
                name: "war_material_delivery_certificate_format_explosives",
                newName: "WarMaterialDeliveryCertificateFormatExplosives");

            migrationBuilder.RenameTable(
                name: "war_material_delivery_certificate_format_equipments",
                newName: "WarMaterialDeliveryCertificateFormatEquipments");

            migrationBuilder.RenameTable(
                name: "war_material_delivery_certificate_format_ammunition",
                newName: "WarMaterialDeliveryCertificateFormatAmmunition");

            migrationBuilder.RenameTable(
                name: "war_material_and_special_equipment_assignment_formats",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormats");

            migrationBuilder.RenameTable(
                name: "war_material_and_special_equipment_assignment_format_weapons",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons");

            migrationBuilder.RenameTable(
                name: "war_material_and_special_equipment_assignment_format_explosives",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives");

            migrationBuilder.RenameTable(
                name: "war_material_and_special_equipment_assignment_format_equipments",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments");

            migrationBuilder.RenameTable(
                name: "war_material_and_special_equipment_assignment_format_ammunition",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition");

            migrationBuilder.RenameTable(
                name: "assigned_weapon_magazine_formats",
                newName: "AssignedWeaponMagazineFormats");

            migrationBuilder.RenameTable(
                name: "assigned_weapon_magazine_format_items",
                newName: "AssignedWeaponMagazineFormatItems");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Weapons",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "Weapons",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "Weapons",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Weapons",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "Weapons",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "lot",
                table: "Weapons",
                newName: "Lot");

            migrationBuilder.RenameColumn(
                name: "caliber",
                table: "Weapons",
                newName: "Caliber");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Weapons",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "troop_id",
                table: "Weapons",
                newName: "TroopId");

            migrationBuilder.RenameColumn(
                name: "provider_capacity",
                table: "Weapons",
                newName: "ProviderCapacity");

            migrationBuilder.RenameColumn(
                name: "number_of_providers",
                table: "Weapons",
                newName: "NumberOfProviders");

            migrationBuilder.RenameIndex(
                name: "ix_weapons_series",
                table: "Weapons",
                newName: "IX_Weapons_Series");

            migrationBuilder.RenameIndex(
                name: "ix_weapons_lot",
                table: "Weapons",
                newName: "IX_Weapons_Lot");

            migrationBuilder.RenameIndex(
                name: "ix_weapons_troop_id",
                table: "Weapons",
                newName: "IX_Weapons_TroopId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Troopers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "Troopers",
                newName: "SquadCode");

            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "Troopers",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "second_last_name",
                table: "Troopers",
                newName: "SecondLastName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Troopers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Troopers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "degree_id",
                table: "Troopers",
                newName: "DegreeId");

            migrationBuilder.RenameIndex(
                name: "ix_troopers_squad_code",
                table: "Troopers",
                newName: "IX_Troopers_SquadCode");

            migrationBuilder.RenameIndex(
                name: "ix_troopers_degree_id",
                table: "Troopers",
                newName: "IX_Troopers_DegreeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Squads",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Squads",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "Squads",
                newName: "SquadronCode");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Squads",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "ix_squads_squadron_code",
                table: "Squads",
                newName: "IX_Squads_SquadronCode");

            migrationBuilder.RenameIndex(
                name: "ix_squads_person_id",
                table: "Squads",
                newName: "IX_Squads_PersonId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Squadrons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Squadrons",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Squadrons",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "ix_squadrons_person_id",
                table: "Squadrons",
                newName: "IX_Squadrons_PersonId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ranks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ranks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "People",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "second_name",
                table: "People",
                newName: "SecondName");

            migrationBuilder.RenameColumn(
                name: "second_last_name",
                table: "People",
                newName: "SecondLastName");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "People",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "People",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "armory_user_id",
                table: "People",
                newName: "ArmoryUserId");

            migrationBuilder.RenameIndex(
                name: "ix_people_armory_user_id",
                table: "People",
                newName: "IX_People_ArmoryUserId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Explosives",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "Explosives",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "Explosives",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "lot",
                table: "Explosives",
                newName: "Lot");

            migrationBuilder.RenameColumn(
                name: "caliber",
                table: "Explosives",
                newName: "Caliber");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Explosives",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "quantity_available",
                table: "Explosives",
                newName: "QuantityAvailable");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Equipments",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "Equipments",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Equipments",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Equipments",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "quantity_available",
                table: "Equipments",
                newName: "QuantityAvailable");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Degrees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Degrees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "rank_id",
                table: "Degrees",
                newName: "RankId");

            migrationBuilder.RenameIndex(
                name: "ix_degrees_rank_id",
                table: "Degrees",
                newName: "IX_Degrees_RankId");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "AspNetUsers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AspNetUsers",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "two_factor_enabled",
                table: "AspNetUsers",
                newName: "TwoFactorEnabled");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "AspNetUsers",
                newName: "SecurityStamp");

            migrationBuilder.RenameColumn(
                name: "phone_number_confirmed",
                table: "AspNetUsers",
                newName: "PhoneNumberConfirmed");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "AspNetUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "AspNetUsers",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AspNetUsers",
                newName: "NormalizedUserName");

            migrationBuilder.RenameColumn(
                name: "normalized_email",
                table: "AspNetUsers",
                newName: "NormalizedEmail");

            migrationBuilder.RenameColumn(
                name: "lockout_end",
                table: "AspNetUsers",
                newName: "LockoutEnd");

            migrationBuilder.RenameColumn(
                name: "lockout_enabled",
                table: "AspNetUsers",
                newName: "LockoutEnabled");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "AspNetUsers",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetUsers",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "AspNetUsers",
                newName: "AccessFailedCount");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_users_phone_number",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_PhoneNumber");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_users_email",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Email");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Ammunition",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "series",
                table: "Ammunition",
                newName: "Series");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "Ammunition",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "lot",
                table: "Ammunition",
                newName: "Lot");

            migrationBuilder.RenameColumn(
                name: "caliber",
                table: "Ammunition",
                newName: "Caliber");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Ammunition",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "quantity_available",
                table: "Ammunition",
                newName: "QuantityAvailable");

            migrationBuilder.RenameColumn(
                name: "validity",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "Validity");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "troop_id",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "TroopId");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "SquadronCode");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "SquadCode");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_troop_id",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "IX_WarMaterialDeliveryCertificateFormats_TroopId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_squadron_code",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "IX_WarMaterialDeliveryCertificateFormats_SquadronCode");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_formats_squad_code",
                table: "WarMaterialDeliveryCertificateFormats",
                newName: "IX_WarMaterialDeliveryCertificateFormats_SquadCode");

            migrationBuilder.RenameColumn(
                name: "weapon_code",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                newName: "WeaponCode");

            migrationBuilder.RenameColumn(
                name: "war_material_delivery_certificate_format_id",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                newName: "WarMaterialDeliveryCertificateFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_format_weapons_weapon_code",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                newName: "IX_WarMaterialDeliveryCertificateFormatWeapons_WeaponCode");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "explosive_code",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                newName: "ExplosiveCode");

            migrationBuilder.RenameColumn(
                name: "war_material_delivery_certificate_format_id",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                newName: "WarMaterialDeliveryCertificateFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_format_explosives_explosiv",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                newName: "IX_WarMaterialDeliveryCertificateFormatExplosives_ExplosiveCode");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "equipment_code",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                newName: "EquipmentCode");

            migrationBuilder.RenameColumn(
                name: "war_material_delivery_certificate_format_id",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                newName: "WarMaterialDeliveryCertificateFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_format_equipments_equipmen",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                newName: "IX_WarMaterialDeliveryCertificateFormatEquipments_EquipmentCode");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ammunition_code",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                newName: "AmmunitionCode");

            migrationBuilder.RenameColumn(
                name: "war_material_delivery_certificate_format_id",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                newName: "WarMaterialDeliveryCertificateFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_delivery_certificate_format_ammunition_ammuniti",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                newName: "IX_WarMaterialDeliveryCertificateFormatAmmunition_AmmunitionCode");

            migrationBuilder.RenameColumn(
                name: "warehouse",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "validity",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Validity");

            migrationBuilder.RenameColumn(
                name: "purpose",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Purpose");

            migrationBuilder.RenameColumn(
                name: "place",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Place");

            migrationBuilder.RenameColumn(
                name: "others",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Others");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "troop_id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "TroopId");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "SquadronCode");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "SquadCode");

            migrationBuilder.RenameColumn(
                name: "physical_location",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "PhysicalLocation");

            migrationBuilder.RenameColumn(
                name: "doc_movement",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "DocMovement");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_troop_",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_TroopId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squadr",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadronCode");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_formats_squad_",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormats_SquadCode");

            migrationBuilder.RenameColumn(
                name: "weapon_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                newName: "WeaponCode");

            migrationBuilder.RenameColumn(
                name: "war_material_and_special_equipment_assignment_format_id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_weapons",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "explosive_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                newName: "ExplosiveCode");

            migrationBuilder.RenameColumn(
                name: "war_material_and_special_equipment_assignment_format_id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_explosi",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "equipment_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                newName: "EquipmentCode");

            migrationBuilder.RenameColumn(
                name: "war_material_and_special_equipment_assignment_format_id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatId");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_equipme",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "war_material_and_special_equipment_assignment_format_id",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                newName: "WarMaterialAndSpecialEquipmentAssignmentFormatId");

            migrationBuilder.RenameColumn(
                name: "ammunition_code",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                newName: "AmmunitionCode");

            migrationBuilder.RenameIndex(
                name: "ix_war_material_and_special_equipment_assignment_format_ammunit",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                newName: "IX_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~");

            migrationBuilder.RenameColumn(
                name: "warehouse",
                table: "AssignedWeaponMagazineFormats",
                newName: "Warehouse");

            migrationBuilder.RenameColumn(
                name: "validity",
                table: "AssignedWeaponMagazineFormats",
                newName: "Validity");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "AssignedWeaponMagazineFormats",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "comments",
                table: "AssignedWeaponMagazineFormats",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "AssignedWeaponMagazineFormats",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AssignedWeaponMagazineFormats",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "squadron_code",
                table: "AssignedWeaponMagazineFormats",
                newName: "SquadronCode");

            migrationBuilder.RenameColumn(
                name: "squad_code",
                table: "AssignedWeaponMagazineFormats",
                newName: "SquadCode");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_squadron_code",
                table: "AssignedWeaponMagazineFormats",
                newName: "IX_AssignedWeaponMagazineFormats_SquadronCode");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_formats_squad_code",
                table: "AssignedWeaponMagazineFormats",
                newName: "IX_AssignedWeaponMagazineFormats_SquadCode");

            migrationBuilder.RenameColumn(
                name: "observations",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "Observations");

            migrationBuilder.RenameColumn(
                name: "novelty",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "Novelty");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "weapon_code",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "WeaponCode");

            migrationBuilder.RenameColumn(
                name: "verified_in_physical",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "VerifiedInPhysical");

            migrationBuilder.RenameColumn(
                name: "troop_id",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "TroopId");

            migrationBuilder.RenameColumn(
                name: "cartridge_of_life",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "CartridgeOfLife");

            migrationBuilder.RenameColumn(
                name: "assigned_weapon_magazine_format_id",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "AssignedWeaponMagazineFormatId");

            migrationBuilder.RenameColumn(
                name: "ammunition_quantity",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "AmmunitionQuantity");

            migrationBuilder.RenameColumn(
                name: "ammunition_lot",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "AmmunitionLot");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_format_items_weapon_code",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "IX_AssignedWeaponMagazineFormatItems_WeaponCode");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_format_items_troop_id",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "IX_AssignedWeaponMagazineFormatItems_TroopId");

            migrationBuilder.RenameIndex(
                name: "ix_assigned_weapon_magazine_format_items_assigned_weapon_magazi",
                table: "AssignedWeaponMagazineFormatItems",
                newName: "IX_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Troopers",
                table: "Troopers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squads",
                table: "Squads",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Squadrons",
                table: "Squadrons",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ranks",
                table: "Ranks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Explosives",
                table: "Explosives",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ammunition",
                table: "Ammunition",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormats",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatWeapons",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                columns: new[] { "WarMaterialDeliveryCertificateFormatId", "WeaponCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatExplosives",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                columns: new[] { "WarMaterialDeliveryCertificateFormatId", "ExplosiveCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatEquipments",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                columns: new[] { "WarMaterialDeliveryCertificateFormatId", "EquipmentCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialDeliveryCertificateFormatAmmunition",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                columns: new[] { "WarMaterialDeliveryCertificateFormatId", "AmmunitionCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormats",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                columns: new[] { "WarMaterialAndSpecialEquipmentAssignmentFormatId", "WeaponCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                columns: new[] { "WarMaterialAndSpecialEquipmentAssignmentFormatId", "ExplosiveCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                columns: new[] { "WarMaterialAndSpecialEquipmentAssignmentFormatId", "EquipmentCode" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                columns: new[] { "AmmunitionCode", "WarMaterialAndSpecialEquipmentAssignmentFormatId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedWeaponMagazineFormats",
                table: "AssignedWeaponMagazineFormats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignedWeaponMagazineFormatItems",
                table: "AssignedWeaponMagazineFormatItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_AssignedWeaponMagazineForm~",
                table: "AssignedWeaponMagazineFormatItems",
                column: "AssignedWeaponMagazineFormatId",
                principalTable: "AssignedWeaponMagazineFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Troopers_TroopId",
                table: "AssignedWeaponMagazineFormatItems",
                column: "TroopId",
                principalTable: "Troopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormatItems_Weapons_WeaponCode",
                table: "AssignedWeaponMagazineFormatItems",
                column: "WeaponCode",
                principalTable: "Weapons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormats_Squadrons_SquadronCode",
                table: "AssignedWeaponMagazineFormats",
                column: "SquadronCode",
                principalTable: "Squadrons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignedWeaponMagazineFormats_Squads_SquadCode",
                table: "AssignedWeaponMagazineFormats",
                column: "SquadCode",
                principalTable: "Squads",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Ranks_RankId",
                table: "Degrees",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AspNetUsers_ArmoryUserId",
                table: "People",
                column: "ArmoryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Squadrons_People_PersonId",
                table: "Squadrons",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_People_PersonId",
                table: "Squads",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Squads_Squadrons_SquadronCode",
                table: "Squads",
                column: "SquadronCode",
                principalTable: "Squadrons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Troopers_Degrees_DegreeId",
                table: "Troopers",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Troopers_Squads_SquadCode",
                table: "Troopers",
                column: "SquadCode",
                principalTable: "Squads",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_Amm~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                column: "AmmunitionCode",
                principalTable: "Ammunition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatAmmunition",
                column: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_Equ~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                column: "EquipmentCode",
                principalTable: "Equipments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatEquipments_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatEquipments",
                column: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_Exp~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                column: "ExplosiveCode",
                principalTable: "Explosives",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatExplosives_War~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatExplosives",
                column: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squadrons_Sq~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "SquadronCode",
                principalTable: "Squadrons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Squads_Squad~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "SquadCode",
                principalTable: "Squads",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormats_Troopers_Tro~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                column: "TroopId",
                principalTable: "Troopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_WarMat~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                column: "WarMaterialAndSpecialEquipmentAssignmentFormatId",
                principalTable: "WarMaterialAndSpecialEquipmentAssignmentFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialAndSpecialEquipmentAssignmentFormatWeapons_Weapon~",
                table: "WarMaterialAndSpecialEquipmentAssignmentFormatWeapons",
                column: "WeaponCode",
                principalTable: "Weapons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_Ammunition_Am~",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                column: "AmmunitionCode",
                principalTable: "Ammunition",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatAmmunition_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatAmmunition",
                column: "WarMaterialDeliveryCertificateFormatId",
                principalTable: "WarMaterialDeliveryCertificateFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatEquipments_Equipments_Eq~",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                column: "EquipmentCode",
                principalTable: "Equipments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatEquipments_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatEquipments",
                column: "WarMaterialDeliveryCertificateFormatId",
                principalTable: "WarMaterialDeliveryCertificateFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatExplosives_Explosives_Ex~",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                column: "ExplosiveCode",
                principalTable: "Explosives",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatExplosives_WarMaterialDe~",
                table: "WarMaterialDeliveryCertificateFormatExplosives",
                column: "WarMaterialDeliveryCertificateFormatId",
                principalTable: "WarMaterialDeliveryCertificateFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Squadrons_SquadronCode",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "SquadronCode",
                principalTable: "Squadrons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Squads_SquadCode",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "SquadCode",
                principalTable: "Squads",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormats_Troopers_TroopId",
                table: "WarMaterialDeliveryCertificateFormats",
                column: "TroopId",
                principalTable: "Troopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatWeapons_WarMaterialDeliv~",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                column: "WarMaterialDeliveryCertificateFormatId",
                principalTable: "WarMaterialDeliveryCertificateFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarMaterialDeliveryCertificateFormatWeapons_Weapons_WeaponCo~",
                table: "WarMaterialDeliveryCertificateFormatWeapons",
                column: "WeaponCode",
                principalTable: "Weapons",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Troopers_TroopId",
                table: "Weapons",
                column: "TroopId",
                principalTable: "Troopers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
