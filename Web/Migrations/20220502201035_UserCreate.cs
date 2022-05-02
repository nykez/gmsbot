using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class UserCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("945afdf4-59cf-4b27-a92f-3c6cf7df2783"));

            migrationBuilder.CreateTable(
                name: "BotUsers",
                columns: table => new
                {
                    DiscordId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SteamId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotUsers", x => x.DiscordId);
                });

            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("ff04f879-50e5-452c-8a1b-82f76f4a0e42"), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotUsers");

            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("ff04f879-50e5-452c-8a1b-82f76f4a0e42"));

            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("945afdf4-59cf-4b27-a92f-3c6cf7df2783"), null });
        }
    }
}
