using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPolicyInsurance.Migrations
{
    public partial class initialDBwithseeding : Migration
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
                    { 581718, "80160020", new DateTime(2022, 1, 14, 14, 35, 52, 466, DateTimeKind.Local).AddTicks(3765), new DateTime(2024, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(373), "Joe", "Burrow", 350.0m },
                    { 573055, "76286605", new DateTime(2021, 4, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2111), new DateTime(2025, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2128), "Ja'Marr", "Chase", 225.0m },
                    { 418377, "63919800", new DateTime(2014, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2143), new DateTime(2018, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2145), "Mark", "Stone", 145.0m },
                    { 148906, "60458528", new DateTime(2019, 11, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2150), new DateTime(2021, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2152), "Larry", "Johnson", 225.0m },
                    { 823615, "86985124", new DateTime(2021, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2155), new DateTime(2025, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2157), "Steph", "Curry", 315.0m },
                    { 332372, "12713028", new DateTime(2022, 1, 14, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2161), new DateTime(2027, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2163), "Draymond", "Green", 200.0m },
                    { 539379, "17282181", new DateTime(2014, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2242), new DateTime(2020, 6, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2245), "Andrew", "Wiggins", 225.0m },
                    { 949164, "10111757", new DateTime(2020, 11, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2249), new DateTime(2025, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2251), "Debo", "Samuel", 345.0m },
                    { 723592, "08007355", new DateTime(2016, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2255), new DateTime(2021, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2257), "Cooper", "Kupp", 65.0m },
                    { 493847, "61527897", new DateTime(2016, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2260), new DateTime(2021, 2, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2262), "Kobe", "Bryant", 65.0m },
                    { 609698, "82404778", new DateTime(2022, 1, 29, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2266), new DateTime(2025, 10, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2267), "Kyrie", "Irving", 311.0m },
                    { 103575, "82302017", new DateTime(2020, 9, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2271), new DateTime(2024, 8, 13, 14, 35, 52, 469, DateTimeKind.Local).AddTicks(2273), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 581718, "45215", "OH", "123 Main St" },
                    { 2, "Cincinatti", 573055, "45203", "OH", "77 Elm Avenue" },
                    { 11, "Brooklyn", 609698, "11211", "NY", "123 Fulton Street" },
                    { 3, "Las Vegas", 418377, "89105", "NV", "702 Flamingo Rd" },
                    { 4, "Henderson", 148906, "89119", "NV", "21 Tropicana Ave" },
                    { 10, "Newport", 493847, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 823615, "94117", "CA", "88 Haight St" },
                    { 6, "San Fransisco", 332372, "94117", "CA", "420 Ashbury" },
                    { 12, "Brooklyn", 103575, "11206", "NY", "1120 Flatbush Ave " },
                    { 7, "Oakland", 539379, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 723592, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 8, "Oakland", 949164, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 609698, "Lamborghini", "Huracan", 2022 },
                    { 10, 493847, "McLaren", "F1", 2020 },
                    { 9, 723592, "Chevrolet", "Tahoe", 1993 },
                    { 6, 332372, "Oldsmobile", "Cutlass", 1967 },
                    { 7, 539379, "Shelby", "G.T. 350", 2020 },
                    { 5, 823615, "Mercedes-benz", "SL-63", 2019 },
                    { 4, 148906, "Dodge", "Viper", 1995 },
                    { 3, 418377, "Ford", "Mustang", 1966 },
                    { 2, 573055, "Porsche", "Macan", 2022 },
                    { 1, 581718, "Tesla", "Model X", 2020 },
                    { 8, 949164, "BMW", "M6", 2021 },
                    { 12, 103575, "Tesla", "Model X", 2021 }
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
