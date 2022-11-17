using Microsoft.EntityFrameworkCore.Migrations;

namespace FlexWheelsNew.Migrations
{
    public partial class bbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycle_Bookings_Bookingsbooking_id",
                table: "Bicycle");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Bicycle_bicycle_id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_bicycle_id",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bicycle_Bookingsbooking_id",
                table: "Bicycle");

            migrationBuilder.DropColumn(
                name: "bicycle_brandname",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "bicycle_id",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Bookingsbooking_id",
                table: "Bicycle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bicycle_brandname",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "bicycle_id",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bookingsbooking_id",
                table: "Bicycle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_bicycle_id",
                table: "Bookings",
                column: "bicycle_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_Bookingsbooking_id",
                table: "Bicycle",
                column: "Bookingsbooking_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_Bookings_Bookingsbooking_id",
                table: "Bicycle",
                column: "Bookingsbooking_id",
                principalTable: "Bookings",
                principalColumn: "booking_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Bicycle_bicycle_id",
                table: "Bookings",
                column: "bicycle_id",
                principalTable: "Bicycle",
                principalColumn: "bicycle_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
