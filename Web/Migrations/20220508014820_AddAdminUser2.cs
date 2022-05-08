using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AddAdminUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512e8d8-dde1-4def-bf56-d3f1ecef1a1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8493f0be-66d9-4b6b-875f-15b0cda8935b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1daacfc0-938d-4b12-bf34-1313a3524c82", "efdbd608-bbe2-4aee-ab1e-fbc74ac3a15b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1daacfc0-938d-4b12-bf34-1313a3524c82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efdbd608-bbe2-4aee-ab1e-fbc74ac3a15b");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "1512e8d8-dde1-4def-bf56-d3f1ecef1a1f", "9f78d5ce-505e-4fdd-81ad-313898416a2f", "Support Rep", null },
                    { "1daacfc0-938d-4b12-bf34-1313a3524c82", "756d7aa1-eccd-4fd9-8a0a-5d4577f628d3", "Admin", null },
                    { "8493f0be-66d9-4b6b-875f-15b0cda8935b", "be9ae78d-fb77-4258-a957-64432a6a3afc", "Moderator", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SteamId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efdbd608-bbe2-4aee-ab1e-fbc74ac3a15b", 0, "060125cb-4102-4b17-885d-ef960ec92329", "admin@admin.com", false, false, null, null, null, null, null, false, "2745a17a-7d1b-48f8-873a-b3f23bca5e94", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1daacfc0-938d-4b12-bf34-1313a3524c82", "efdbd608-bbe2-4aee-ab1e-fbc74ac3a15b" });
        }
    }
}
