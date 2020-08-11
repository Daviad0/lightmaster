using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LightMasterMVVM.Migrations
{
    public partial class Reframework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FRCTeams",
                columns: table => new
                {
                    event_key = table.Column<string>(nullable: false),
                    team_number = table.Column<int>(nullable: false),
                    rated_tier = table.Column<string>(nullable: true),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRCTeams", x => new { x.team_number, x.event_key });
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TabletId = table.Column<string>(nullable: true),
                    IsQualifying = table.Column<bool>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: true),
                    MatchNumber = table.Column<int>(nullable: false),
                    RobotPosition = table.Column<string>(nullable: true),
                    ScoutName = table.Column<string>(nullable: true),
                    A_InitiationLine = table.Column<bool>(nullable: false),
                    PowerCellMissed = table.Column<int[]>(nullable: true),
                    PowerCellLower = table.Column<int[]>(nullable: true),
                    PowerCellOuter = table.Column<int[]>(nullable: true),
                    PowerCellInner = table.Column<int[]>(nullable: true),
                    NumCycles = table.Column<int>(nullable: false),
                    T_ControlPanelRotation = table.Column<bool>(nullable: false),
                    T_ControlPanelPosition = table.Column<bool>(nullable: false),
                    E_Park = table.Column<bool>(nullable: false),
                    E_ClimbAttempt = table.Column<bool>(nullable: false),
                    E_ClimbSuccess = table.Column<bool>(nullable: false),
                    E_Balanced = table.Column<bool>(nullable: false),
                    DisabledSeconds = table.Column<int>(nullable: false),
                    ClientSubmitted = table.Column<bool>(nullable: false),
                    ClientLastSubmitted = table.Column<DateTime>(nullable: false),
                    APIChecked = table.Column<bool>(nullable: false),
                    APIAccuracy = table.Column<int>(nullable: false),
                    TapLogs = table.Column<string[]>(nullable: true),
                    TrackedTeamteam_number = table.Column<int>(nullable: true),
                    TrackedTeamevent_key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                    table.ForeignKey(
                        name: "FK_Matches_FRCTeams_TrackedTeamteam_number_TrackedTeamevent_key",
                        columns: x => new { x.TrackedTeamteam_number, x.TrackedTeamevent_key },
                        principalTable: "FRCTeams",
                        principalColumns: new[] { "team_number", "event_key" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TrackedTeamteam_number_TrackedTeamevent_key",
                table: "Matches",
                columns: new[] { "TrackedTeamteam_number", "TrackedTeamevent_key" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "FRCTeams");
        }
    }
}
