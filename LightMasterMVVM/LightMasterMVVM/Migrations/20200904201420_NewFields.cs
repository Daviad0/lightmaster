using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LightMasterMVVM.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_FRCTeams_TrackedTeamteam_number_TrackedTeamevent_key",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TrackedTeamteam_number_TrackedTeamevent_key",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FRCTeams",
                table: "FRCTeams");

            migrationBuilder.DropColumn(
                name: "TrackedTeamevent_key",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TrackedTeamteam_number",
                table: "Matches");

            migrationBuilder.AddColumn<int[]>(
                name: "AlliancePartners",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CycleTime",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DefenseAgainst",
                table: "Matches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DefenseFor",
                table: "Matches",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int[]>(
                name: "LoadCoordinates",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "ShotCoordinates",
                table: "Matches",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "team_instance_id",
                table: "Matches",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "event_key",
                table: "FRCTeams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "team_instance_id",
                table: "FRCTeams",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FRCTeams",
                table: "FRCTeams",
                column: "team_instance_id");

            migrationBuilder.CreateTable(
                name: "TBAMatches",
                columns: table => new
                {
                    key = table.Column<string>(nullable: false),
                    rawjson = table.Column<string>(nullable: true),
                    match_number = table.Column<int>(nullable: false),
                    isqualifying = table.Column<bool>(nullable: false),
                    event_key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAMatches", x => x.key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_team_instance_id",
                table: "Matches",
                column: "team_instance_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_FRCTeams_team_instance_id",
                table: "Matches",
                column: "team_instance_id",
                principalTable: "FRCTeams",
                principalColumn: "team_instance_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_FRCTeams_team_instance_id",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "TBAMatches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_team_instance_id",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FRCTeams",
                table: "FRCTeams");

            migrationBuilder.DropColumn(
                name: "AlliancePartners",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CycleTime",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "DefenseAgainst",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "DefenseFor",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "LoadCoordinates",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ShotCoordinates",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "team_instance_id",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "team_instance_id",
                table: "FRCTeams");

            migrationBuilder.AddColumn<string>(
                name: "TrackedTeamevent_key",
                table: "Matches",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackedTeamteam_number",
                table: "Matches",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "event_key",
                table: "FRCTeams",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FRCTeams",
                table: "FRCTeams",
                columns: new[] { "team_number", "event_key" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TrackedTeamteam_number_TrackedTeamevent_key",
                table: "Matches",
                columns: new[] { "TrackedTeamteam_number", "TrackedTeamevent_key" });

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_FRCTeams_TrackedTeamteam_number_TrackedTeamevent_key",
                table: "Matches",
                columns: new[] { "TrackedTeamteam_number", "TrackedTeamevent_key" },
                principalTable: "FRCTeams",
                principalColumns: new[] { "team_number", "event_key" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
