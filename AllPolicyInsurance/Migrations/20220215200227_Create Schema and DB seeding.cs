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
                    { 863871, "50725819", new DateTime(2022, 1, 16, 12, 2, 27, 257, DateTimeKind.Local).AddTicks(369), new DateTime(2024, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(2491), "Joe", "Burrow", 350.0m },
                    { 319655, "85190713", new DateTime(2021, 4, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4076), new DateTime(2025, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4092), "Ja'Marr", "Chase", 225.0m },
                    { 399217, "74907111", new DateTime(2014, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4107), new DateTime(2018, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4110), "Mark", "Stone", 145.0m },
                    { 769245, "72600482", new DateTime(2019, 11, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4114), new DateTime(2021, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4117), "Larry", "Johnson", 225.0m },
                    { 972348, "15100935", new DateTime(2021, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4120), new DateTime(2025, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4122), "Steph", "Curry", 315.0m },
                    { 109164, "43283972", new DateTime(2022, 1, 16, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4126), new DateTime(2027, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4128), "Draymond", "Green", 200.0m },
                    { 134365, "60933490", new DateTime(2014, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4132), new DateTime(2020, 6, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4134), "Andrew", "Wiggins", 225.0m },
                    { 710259, "48275090", new DateTime(2020, 11, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4138), new DateTime(2025, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4141), "Debo", "Samuel", 345.0m },
                    { 380041, "42720420", new DateTime(2016, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4145), new DateTime(2021, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4148), "Cooper", "Kupp", 65.0m },
                    { 788741, "44321177", new DateTime(2016, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4151), new DateTime(2021, 2, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4154), "Kobe", "Bryant", 65.0m },
                    { 253905, "56200559", new DateTime(2022, 1, 31, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4157), new DateTime(2025, 10, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4159), "Kyrie", "Irving", 311.0m },
                    { 558865, "79062485", new DateTime(2020, 9, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4163), new DateTime(2024, 8, 15, 12, 2, 27, 259, DateTimeKind.Local).AddTicks(4166), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 863871, "45215", "OH", "123 Main St" },
                    { 7, "Oakland", 134365, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 380041, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 6, "San Fransisco", 109164, "94117", "CA", "420 Ashbury" },
                    { 10, "Newport", 788741, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 972348, "94117", "CA", "88 Haight St" },
                    { 11, "Brooklyn", 253905, "11211", "NY", "123 Fulton Street" },
                    { 4, "Henderson", 769245, "89119", "NV", "21 Tropicana Ave" },
                    { 2, "Cincinatti", 319655, "45203", "OH", "77 Elm Avenue" },
                    { 12, "Brooklyn", 558865, "11206", "NY", "1120 Flatbush Ave " },
                    { 3, "Las Vegas", 399217, "89105", "NV", "702 Flamingo Rd" },
                    { 8, "Oakland", 710259, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 710259, "BMW", "M6", "2021" },
                    { 13, 788741, "McLaren", "F1", "2020" },
                    { 14, 253905, "Lamborghini", "Huracan", "2022" },
                    { 12, 380041, "Chevrolet", "Tahoe", "1993" },
                    { 15, 558865, "Tesla", "Model X", "2021" },
                    { 16, 558865, "Porsche", "911 Turbo S", "2020" },
                    { 9, 109164, "Oldsmobile", "Cutlass", "1967" },
                    { 17, 558865, "Chevrolet", "Corvette Sting Ray", "1963" },
                    { 8, 972348, "Acura", "NSX", "1990" },
                    { 7, 972348, "Mercedes-benz", "SL-63", "2019" },
                    { 6, 769245, "Dodge", "Viper", "1995" },
                    { 5, 399217, "Ford", "Mustang", "1966" },
                    { 4, 319655, "Porsche", "Macan", "2022" },
                    { 3, 863871, "GMC", "Suburban", "2014" },
                    { 2, 863871, "BMW", "Z4", "2008" },
                    { 1, 863871, "Tesla", "Model X", "2020" },
                    { 10, 134365, "Shelby", "G.T. 350", "2020" },
                    { 18, 558865, "Aston Martin", "DB4 GT Zagato", "1960" }
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
