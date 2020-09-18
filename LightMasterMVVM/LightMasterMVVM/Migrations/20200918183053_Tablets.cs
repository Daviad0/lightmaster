using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightMasterMVVM.Migrations
{
    public partial class Tablets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabletInstances",
                columns: table => new
                {
                    Identifier = table.Column<string>(nullable: false),
                    TabletName = table.Column<string>(nullable: true),
                    LastKnownBattery = table.Column<int>(nullable: false),
                    AuthenticationLevel = table.Column<int>(nullable: false),
                    ColorId = table.Column<string>(nullable: true),
                    LastCommunicated = table.Column<DateTime>(nullable: false),
                    DiagnosticReportReceived = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabletInstances", x => x.Identifier);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabletInstances");
        }
    }
}
