using Microsoft.EntityFrameworkCore.Migrations;

namespace FlexWheelsNew.Migrations
{
    public partial class _123221wqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialSecurityNumber = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreLocation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "Bicycle_bookings",
                columns: table => new
                {
                    bicycle_id = table.Column<int>(type: "int", nullable: false),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false),
                    CustomerCID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycle_bookings", x => new { x.bicycle_id, x.booking_id });
                    table.ForeignKey(
                        name: "FK_Bicycle_bookings_Customer_CustomerCID",
                        column: x => x.CustomerCID,
                        principalTable: "Customer",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    bicycle_id = table.Column<int>(type: "int", nullable: true),
                    rent_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    return_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bicycle_brandname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customer_booking_id",
                        column: x => x.booking_id,
                        principalTable: "Customer",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bicycle",
                columns: table => new
                {
                    bicycle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bicycle_brandname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wheeltype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bicycleprice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    Bookingsbooking_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycle", x => x.bicycle_id);
                    table.ForeignKey(
                        name: "FK_Bicycle_Bookings_Bookingsbooking_id",
                        column: x => x.Bookingsbooking_id,
                        principalTable: "Bookings",
                        principalColumn: "booking_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bicycle_Store_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Store",
                        principalColumn: "StoreID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_Bookingsbooking_id",
                table: "Bicycle",
                column: "Bookingsbooking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_StoreID",
                table: "Bicycle",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_bookings_booking_id",
                table: "Bicycle_bookings",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bicycle_bookings_CustomerCID",
                table: "Bicycle_bookings",
                column: "CustomerCID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_bicycle_id",
                table: "Bookings",
                column: "bicycle_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_bookings_Bicycle_bicycle_id",
                table: "Bicycle_bookings",
                column: "bicycle_id",
                principalTable: "Bicycle",
                principalColumn: "bicycle_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycle_bookings_Bookings_booking_id",
                table: "Bicycle_bookings",
                column: "booking_id",
                principalTable: "Bookings",
                principalColumn: "booking_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Bicycle_bicycle_id",
                table: "Bookings",
                column: "bicycle_id",
                principalTable: "Bicycle",
                principalColumn: "bicycle_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycle_Bookings_Bookingsbooking_id",
                table: "Bicycle");

            migrationBuilder.DropTable(
                name: "Bicycle_bookings");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Bicycle");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Store");
        }
    }
}
