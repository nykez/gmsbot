using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf96fd3-9bd9-48b5-8427-a510cbff4a12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7a64fcb-f84e-4ddb-9cae-49893cff5262");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e26daa30-8087-4ae2-b344-d9f598a78dda");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "1cf96fd3-9bd9-48b5-8427-a510cbff4a12", "0c25081d-13ea-472e-829c-876a4844bbea", "Moderator", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7a64fcb-f84e-4ddb-9cae-49893cff5262", "48d08bf9-2013-4b41-84f4-787dcabb9136", "Support Rep", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e26daa30-8087-4ae2-b344-d9f598a78dda", "9752c95b-1292-4732-8fd8-997ec17b5aff", "Admin", null });
        }
    }
}
