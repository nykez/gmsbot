using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
