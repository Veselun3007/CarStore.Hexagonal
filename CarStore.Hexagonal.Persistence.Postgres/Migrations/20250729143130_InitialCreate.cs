using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Hexagonal.Persistence.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    car_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    make = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    vin = table.Column<string>(type: "character varying(17)", maxLength: 17, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "listings",
                columns: table => new
                {
                    listing_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    car_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    dealer_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    listed_price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listings", x => x.listing_id);
                    table.ForeignKey(
                        name: "fk_car_listing",
                        column: x => x.car_id,
                        principalTable: "cars",
                        principalColumn: "car_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_listing_dealer",
                        column: x => x.dealer_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    offer_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    listing_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    customer_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    state = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.offer_id);
                    table.ForeignKey(
                        name: "fk_offer_customer",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_offer_listing",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test_drive_requests",
                columns: table => new
                {
                    test_drive_requests_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    listing_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    customer_id = table.Column<string>(type: "character(36)", fixedLength: true, maxLength: 36, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    requested_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    is_approved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_drive_requests", x => x.test_drive_requests_id);
                    table.ForeignKey(
                        name: "fk_test_drive_customer",
                        column: x => x.customer_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_test_drive_listing",
                        column: x => x.listing_id,
                        principalTable: "listings",
                        principalColumn: "listing_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cars",
                columns: new[] { "car_id", "make", "model", "price", "vin" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000011", "Toyota", "Corolla", 15000.00m, "JH4KA8260MC000001" },
                    { "00000000-0000-0000-0000-000000000012", "Honda", "Civic", 15500.00m, "JH4KA8260MC000002" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "email", "full_name" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", "alice@example.com", "Alice Johnson" },
                    { "00000000-0000-0000-0000-000000000002", "bob.smith@example.com", "Bob Smith" }
                });

            migrationBuilder.InsertData(
                table: "listings",
                columns: new[] { "listing_id", "car_id", "created_at", "dealer_id", "description", "listed_price", "status" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000021", "00000000-0000-0000-0000-000000000011", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000001", "Vehicle in excellent condition, meticulously maintained by a single owner, no issues.", 16000.00m, 0 },
                    { "00000000-0000-0000-0000-000000000022", "00000000-0000-0000-0000-000000000012", new DateTime(2025, 1, 2, 13, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000002", "Exceptionally low mileage, runs and looks like new, barely used and carefully preserved.", 16500.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "offers",
                columns: new[] { "offer_id", "created_at", "customer_id", "listing_id", "price", "state" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000031", new DateTime(2025, 1, 3, 10, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000021", 15800.00m, 0 },
                    { "00000000-0000-0000-0000-000000000032", new DateTime(2025, 1, 4, 11, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000022", 16200.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "test_drive_requests",
                columns: new[] { "test_drive_requests_id", "created_at", "customer_id", "is_approved", "listing_id", "requested_date" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000041", new DateTime(2025, 1, 5, 14, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000002", false, "00000000-0000-0000-0000-000000000021", new DateTime(2025, 1, 10, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { "00000000-0000-0000-0000-000000000042", new DateTime(2025, 1, 6, 15, 0, 0, 0, DateTimeKind.Utc), "00000000-0000-0000-0000-000000000001", false, "00000000-0000-0000-0000-000000000022", new DateTime(2025, 1, 11, 13, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cars_vin",
                table: "cars",
                column: "vin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_listings_car_id",
                table: "listings",
                column: "car_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_listings_dealer_id",
                table: "listings",
                column: "dealer_id");

            migrationBuilder.CreateIndex(
                name: "customers_offer_descending",
                table: "offers",
                columns: new[] { "customer_id", "created_at" },
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_offers_listing_id",
                table: "offers",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "customers_request_descending",
                table: "test_drive_requests",
                columns: new[] { "customer_id", "created_at" },
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_test_drive_requests_listing_id",
                table: "test_drive_requests",
                column: "listing_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "test_drive_requests");

            migrationBuilder.DropTable(
                name: "listings");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
