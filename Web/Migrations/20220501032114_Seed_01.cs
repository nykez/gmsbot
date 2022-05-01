using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class Seed_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SyncRequests",
                columns: new[] { "Id", "DiscordId" },
                values: new object[] { new Guid("945afdf4-59cf-4b27-a92f-3c6cf7df2783"), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SyncRequests",
                keyColumn: "Id",
                keyValue: new Guid("945afdf4-59cf-4b27-a92f-3c6cf7df2783"));
        }
    }
}
