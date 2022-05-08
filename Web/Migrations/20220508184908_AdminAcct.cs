using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AdminAcct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a6c64e-8d94-430d-898f-81958f74a5cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73b99a33-3029-4f77-9084-0b474da854bf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b277e4bf-6c93-4e33-9eb1-0fe4d783fd4f", "e0e78495-d189-4112-9662-090b9b8444a6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b277e4bf-6c93-4e33-9eb1-0fe4d783fd4f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0e78495-d189-4112-9662-090b9b8444a6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25095f24-1036-4aff-b01b-5c0ca64abb48", "9e18be3c-87ee-4f1d-a1d6-25d78a913dc6", "Moderator", null },
                    { "8fe0ee36-8bf4-444f-85f3-62afcfb7ced1", "710641d8-76c3-499d-8fc4-16a84c897956", "Support Rep", null },
                    { "e36412ef-4640-472a-8941-420e7af89773", "ba6f4f9a-e834-4716-a7b0-ba73efe327a6", "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SteamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41232f4e-44ff-47ba-8d43-fe551a9ba52c", 0, "9b447a08-f8e7-422c-a425-c426270b2c8e", "admin@admin.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJqRXVGVZrXMzphwTOMY7QxBpT0u/z1a+8PWbAsLng4SuE7eaQtjxNuCivVFFMRYpw==", null, false, "2a09350b-5b0c-408a-960d-9fde5772ac9e", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e36412ef-4640-472a-8941-420e7af89773", "41232f4e-44ff-47ba-8d43-fe551a9ba52c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25095f24-1036-4aff-b01b-5c0ca64abb48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fe0ee36-8bf4-444f-85f3-62afcfb7ced1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e36412ef-4640-472a-8941-420e7af89773", "41232f4e-44ff-47ba-8d43-fe551a9ba52c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e36412ef-4640-472a-8941-420e7af89773");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41232f4e-44ff-47ba-8d43-fe551a9ba52c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59a6c64e-8d94-430d-898f-81958f74a5cd", "0874a44b-1af4-4579-b518-0ecae64ab626", "Support Rep", null },
                    { "73b99a33-3029-4f77-9084-0b474da854bf", "40156cd6-8990-4122-ad06-1d6997b99714", "Moderator", null },
                    { "b277e4bf-6c93-4e33-9eb1-0fe4d783fd4f", "af125454-daaf-4508-93b6-e599e68badd2", "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SteamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e0e78495-d189-4112-9662-090b9b8444a6", 0, "c90b9577-d683-4769-b95d-7a3291d0a4be", "admin@admin.com", false, false, null, null, null, null, null, false, "12ffc7de-46ff-4029-be29-074a114d6bed", null, false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b277e4bf-6c93-4e33-9eb1-0fe4d783fd4f", "e0e78495-d189-4112-9662-090b9b8444a6" });
        }
    }
}
