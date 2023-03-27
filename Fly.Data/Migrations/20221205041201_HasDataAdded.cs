using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fly.Data.Migrations
{
    /// <inheritdoc />
    public partial class HasDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Planes",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[] { 1, "the simple plane from hasdata method", "https://rukikryki.ru/wp-content/uploads/posts/2018-03/1520082789_08ef1025ce2757b51ff93bb9e7d4dfc0-the-airplane-bald-eagle.jpg", "Plane of HASDATA" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role" },
                values: new object[] { 2, "Administrator-1@admin.admin", "Admin", "c2ef3e415f01b83cf65108505daefccb0e032ccb1aabf45ac0541426a56dbfa5", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Planes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
