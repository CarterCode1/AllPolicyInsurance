using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPolicyInsurance.Migrations
{
    public partial class InitialDBandseeding : Migration
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriversLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Year = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 517619, "23273960", new DateTime(2022, 1, 14, 19, 52, 17, 240, DateTimeKind.Local).AddTicks(1595), new DateTime(2024, 2, 13, 19, 52, 17, 242, DateTimeKind.Local).AddTicks(8722), "Joe", "Burrow", 350.0m },
                    { 753383, "94323642", new DateTime(2021, 4, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(484), new DateTime(2025, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(500), "Ja'Marr", "Chase", 225.0m },
                    { 633382, "07736284", new DateTime(2014, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(516), new DateTime(2018, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(519), "Mark", "Stone", 145.0m },
                    { 377586, "82730184", new DateTime(2019, 11, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(523), new DateTime(2021, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(525), "Larry", "Johnson", 225.0m },
                    { 326399, "35467886", new DateTime(2021, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(528), new DateTime(2025, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(531), "Steph", "Curry", 315.0m },
                    { 256040, "72751840", new DateTime(2022, 1, 14, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(535), new DateTime(2027, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(538), "Draymond", "Green", 200.0m },
                    { 590271, "58838729", new DateTime(2014, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(541), new DateTime(2020, 6, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(543), "Andrew", "Wiggins", 225.0m },
                    { 678700, "01336250", new DateTime(2020, 11, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(546), new DateTime(2025, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(548), "Debo", "Samuel", 345.0m },
                    { 124993, "95852150", new DateTime(2016, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(552), new DateTime(2021, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(554), "Cooper", "Kupp", 65.0m },
                    { 301276, "66274913", new DateTime(2016, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(557), new DateTime(2021, 2, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(559), "Kobe", "Bryant", 65.0m },
                    { 935803, "07736216", new DateTime(2022, 1, 29, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(563), new DateTime(2025, 10, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(565), "Kyrie", "Irving", 311.0m },
                    { 957200, "45660650", new DateTime(2020, 9, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(568), new DateTime(2024, 8, 13, 19, 52, 17, 243, DateTimeKind.Local).AddTicks(570), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 517619, "45215", "OH", "123 Main St" },
                    { 2, "Cincinatti", 753383, "45203", "OH", "77 Elm Avenue" },
                    { 11, "Brooklyn", 935803, "11211", "NY", "123 Fulton Street" },
                    { 3, "Las Vegas", 633382, "89105", "NV", "702 Flamingo Rd" },
                    { 4, "Henderson", 377586, "89119", "NV", "21 Tropicana Ave" },
                    { 10, "Newport", 301276, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 326399, "94117", "CA", "88 Haight St" },
                    { 6, "San Fransisco", 256040, "94117", "CA", "420 Ashbury" },
                    { 12, "Brooklyn", 957200, "11206", "NY", "1120 Flatbush Ave " },
                    { 7, "Oakland", 590271, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 124993, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 8, "Oakland", 678700, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 935803, "Lamborghini", "Huracan", 2022 },
                    { 10, 301276, "McLaren", "F1", 2020 },
                    { 9, 124993, "Chevrolet", "Tahoe", 1993 },
                    { 6, 256040, "Oldsmobile", "Cutlass", 1967 },
                    { 7, 590271, "Shelby", "G.T. 350", 2020 },
                    { 5, 326399, "Mercedes-benz", "SL-63", 2019 },
                    { 4, 377586, "Dodge", "Viper", 1995 },
                    { 3, 633382, "Ford", "Mustang", 1966 },
                    { 2, 753383, "Porsche", "Macan", 2022 },
                    { 1, 517619, "Tesla", "Model X", 2020 },
                    { 8, 678700, "BMW", "M6", 2021 },
                    { 12, 957200, "Tesla", "Model X", 2021 }
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
