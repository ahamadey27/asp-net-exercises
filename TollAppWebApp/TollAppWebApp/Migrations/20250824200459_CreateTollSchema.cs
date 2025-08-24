using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TollAppWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateTollSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlate = table.Column<string>(type: "TEXT", nullable: true),
                    OwnerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TollRecords_VehicleId",
                table: "TollRecords",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TollRecords_Vehicles_VehicleId",
                table: "TollRecords",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TollRecords_Vehicles_VehicleId",
                table: "TollRecords");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_TollRecords_VehicleId",
                table: "TollRecords");
        }
    }
}
