using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LightMasterMVVM.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamNumber = table.Column<int>(nullable: false),
                    TabletId = table.Column<string>(nullable: true),
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
                    ClientSubmitted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
