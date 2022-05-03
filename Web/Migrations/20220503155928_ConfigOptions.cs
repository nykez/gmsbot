using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class ConfigOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("87952c0d-f123-414a-a244-d3df9723b6cf"));

            migrationBuilder.CreateTable(
                name: "AppConfig",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfig", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("47c41aec-f715-476f-893e-31332e3e9c41"), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfig");

            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("47c41aec-f715-476f-893e-31332e3e9c41"));

            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("87952c0d-f123-414a-a244-d3df9723b6cf"), null });
        }
    }
}
