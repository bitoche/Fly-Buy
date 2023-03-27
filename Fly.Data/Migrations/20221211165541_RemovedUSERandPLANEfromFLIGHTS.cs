using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fly.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUSERandPLANEfromFLIGHTS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Users_UserId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_UserId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Flights",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "PlaneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Flights",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PlaneID",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                column: "PlaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_UserId",
                table: "Flights",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Users_UserId",
                table: "Flights",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
