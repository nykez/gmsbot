using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class ConfigOptionsSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("47c41aec-f715-476f-893e-31332e3e9c41"));

            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[] { "bot_token", "" });

            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[] { "gms_token", "" });

            migrationBuilder.InsertData(
                table: "AppConfig",
                columns: new[] { "Key", "Value" },
                values: new object[] { "steamapikey", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "bot_token");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "gms_token");

            migrationBuilder.DeleteData(
                table: "AppConfig",
                keyColumn: "Key",
                keyValue: "steamapikey");

            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("47c41aec-f715-476f-893e-31332e3e9c41"), null });
        }
    }
}
