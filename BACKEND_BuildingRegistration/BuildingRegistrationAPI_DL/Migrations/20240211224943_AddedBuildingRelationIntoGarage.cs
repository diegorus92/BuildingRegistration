using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingRegistrationAPI_DL.Migrations
{
    /// <inheritdoc />
    public partial class AddedBuildingRelationIntoGarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Garages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Garages_BuildingId",
                table: "Garages",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Garages_Buildings_BuildingId",
                table: "Garages",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Garages_Buildings_BuildingId",
                table: "Garages");

            migrationBuilder.DropIndex(
                name: "IX_Garages_BuildingId",
                table: "Garages");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Garages");
        }
    }
}
