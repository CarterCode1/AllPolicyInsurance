using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPolicyInsurance.Migrations
{
    public partial class CreateSchemaandDBseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsurancePolicies",
                columns: table => new
                {
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriversLicenseNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PremiumPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePolicies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    InsurancePolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsurancePolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_InsurancePolicies_InsurancePolicyId",
                        column: x => x.InsurancePolicyId,
                        principalTable: "InsurancePolicies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "InsurancePolicies",
                columns: new[] { "PolicyId", "DriversLicenseNumber", "EffectiveDate", "ExpirationDate", "FirstName", "LastName", "PremiumPrice" },
                values: new object[,]
                {
                    { 739646, "54114066", new DateTime(2022, 1, 16, 7, 49, 23, 31, DateTimeKind.Local).AddTicks(3842), new DateTime(2024, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(6151), "Joe", "Burrow", 350.0m },
                    { 716287, "93445810", new DateTime(2021, 4, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7676), new DateTime(2025, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7694), "Ja'Marr", "Chase", 225.0m },
                    { 705889, "91820223", new DateTime(2014, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7708), new DateTime(2018, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7711), "Mark", "Stone", 145.0m },
                    { 582222, "70126605", new DateTime(2019, 11, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7715), new DateTime(2021, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7718), "Larry", "Johnson", 225.0m },
                    { 637769, "57688514", new DateTime(2021, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7721), new DateTime(2025, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7723), "Steph", "Curry", 315.0m },
                    { 705683, "28668068", new DateTime(2022, 1, 16, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7726), new DateTime(2027, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7728), "Draymond", "Green", 200.0m },
                    { 827976, "10319154", new DateTime(2014, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7732), new DateTime(2020, 6, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7734), "Andrew", "Wiggins", 225.0m },
                    { 945703, "49276028", new DateTime(2020, 11, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7737), new DateTime(2025, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7740), "Debo", "Samuel", 345.0m },
                    { 517229, "22838511", new DateTime(2016, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7795), new DateTime(2021, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7798), "Cooper", "Kupp", 65.0m },
                    { 912358, "35147137", new DateTime(2016, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7802), new DateTime(2021, 2, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7804), "Kobe", "Bryant", 65.0m },
                    { 468308, "33805986", new DateTime(2022, 1, 31, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7807), new DateTime(2025, 10, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7810), "Kyrie", "Irving", 311.0m },
                    { 740556, "86728178", new DateTime(2020, 9, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7813), new DateTime(2024, 8, 15, 7, 49, 23, 33, DateTimeKind.Local).AddTicks(7815), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 739646, "45215", "OH", "123 Main St" },
                    { 7, "Oakland", 827976, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 517229, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 6, "San Fransisco", 705683, "94117", "CA", "420 Ashbury" },
                    { 10, "Newport", 912358, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 637769, "94117", "CA", "88 Haight St" },
                    { 11, "Brooklyn", 468308, "11211", "NY", "123 Fulton Street" },
                    { 4, "Henderson", 582222, "89119", "NV", "21 Tropicana Ave" },
                    { 2, "Cincinatti", 716287, "45203", "OH", "77 Elm Avenue" },
                    { 12, "Brooklyn", 740556, "11206", "NY", "1120 Flatbush Ave " },
                    { 3, "Las Vegas", 705889, "89105", "NV", "702 Flamingo Rd" },
                    { 8, "Oakland", 945703, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 945703, "BMW", "M6", "2021" },
                    { 13, 912358, "McLaren", "F1", "2020" },
                    { 14, 468308, "Lamborghini", "Huracan", "2022" },
                    { 12, 517229, "Chevrolet", "Tahoe", "1993" },
                    { 15, 740556, "Tesla", "Model X", "2021" },
                    { 16, 740556, "Porsche", "911 Turbo S", "2020" },
                    { 9, 705683, "Oldsmobile", "Cutlass", "1967" },
                    { 17, 740556, "Chevrolet", "Corvette Sting Ray", "1963" },
                    { 8, 637769, "Acura", "NSX", "1990" },
                    { 7, 637769, "Mercedes-benz", "SL-63", "2019" },
                    { 6, 582222, "Dodge", "Viper", "1995" },
                    { 5, 705889, "Ford", "Mustang", "1966" },
                    { 4, 716287, "Porsche", "Macan", "2022" },
                    { 3, 739646, "BMW", "Z4", "2008" },
                    { 2, 739646, "GMC", "Suburban", "2014" },
                    { 1, 739646, "Tesla", "Model X", "2020" },
                    { 10, 827976, "Shelby", "G.T. 350", "2020" },
                    { 18, 740556, "Aston Martin", "DB4 GT Zagato", "1960" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_InsurancePolicyId",
                table: "Address",
                column: "InsurancePolicyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_InsurancePolicyId",
                table: "Vehicles",
                column: "InsurancePolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "InsurancePolicies");
        }
    }
}
