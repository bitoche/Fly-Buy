using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fly.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceForPlanes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricePerHour",
                table: "Planes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanePrice",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerHour",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "PlanePrice",
                table: "Flights");
        }
    }
}
