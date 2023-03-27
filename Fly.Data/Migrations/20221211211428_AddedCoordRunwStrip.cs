using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoordRunwStrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoordRunwStrip",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordRunwStrip",
                table: "Planes");
        }
    }
}
