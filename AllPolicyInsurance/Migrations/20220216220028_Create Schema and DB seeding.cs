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
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 324822, "42787182", new DateTime(2022, 1, 17, 14, 0, 28, 553, DateTimeKind.Local).AddTicks(5404), new DateTime(2024, 2, 16, 14, 0, 28, 555, DateTimeKind.Local).AddTicks(8504), "Joe", "Burrow", 350.0m },
                    { 427132, "11761117", new DateTime(2021, 4, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(17), new DateTime(2025, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(33), "Ja'Marr", "Chase", 225.0m },
                    { 277347, "62157047", new DateTime(2014, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(49), new DateTime(2018, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(52), "Mark", "Stone", 145.0m },
                    { 757023, "55467224", new DateTime(2019, 11, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(56), new DateTime(2021, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(58), "Larry", "Johnson", 225.0m },
                    { 318823, "97786428", new DateTime(2021, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(62), new DateTime(2025, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(64), "Steph", "Curry", 315.0m },
                    { 896816, "94649186", new DateTime(2022, 1, 17, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(67), new DateTime(2027, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(70), "Draymond", "Green", 200.0m },
                    { 158000, "80950036", new DateTime(2014, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(73), new DateTime(2020, 6, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(75), "Andrew", "Wiggins", 225.0m },
                    { 552054, "23704829", new DateTime(2020, 11, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(79), new DateTime(2025, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(85), "Debo", "Samuel", 345.0m },
                    { 842518, "65795804", new DateTime(2016, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(88), new DateTime(2021, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(90), "Cooper", "Kupp", 65.0m },
                    { 529256, "90265009", new DateTime(2016, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(94), new DateTime(2021, 2, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(96), "Kobe", "Bryant", 65.0m },
                    { 528124, "68129724", new DateTime(2022, 2, 1, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(99), new DateTime(2025, 10, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(101), "Kyrie", "Irving", 311.0m },
                    { 978371, "02871370", new DateTime(2020, 9, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(105), new DateTime(2024, 8, 16, 14, 0, 28, 556, DateTimeKind.Local).AddTicks(107), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 324822, "45215", "OH", "123 Main St" },
                    { 7, "Oakland", 158000, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 842518, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 6, "San Fransisco", 896816, "94117", "CA", "420 Ashbury" },
                    { 10, "Newport", 529256, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 318823, "94117", "CA", "88 Haight St" },
                    { 11, "Brooklyn", 528124, "11211", "NY", "123 Fulton Street" },
                    { 4, "Henderson", 757023, "89119", "NV", "21 Tropicana Ave" },
                    { 2, "Cincinatti", 427132, "45203", "OH", "77 Elm Avenue" },
                    { 12, "Brooklyn", 978371, "11206", "NY", "1120 Flatbush Ave " },
                    { 3, "Las Vegas", 277347, "89105", "NV", "702 Flamingo Rd" },
                    { 8, "Oakland", 552054, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 552054, "BMW", "M6", "2021" },
                    { 13, 529256, "McLaren", "F1", "2020" },
                    { 14, 528124, "Lamborghini", "Huracan", "2022" },
                    { 12, 842518, "Chevrolet", "Tahoe", "1993" },
                    { 15, 978371, "Tesla", "Model X", "2021" },
                    { 16, 978371, "Porsche", "911 Turbo S", "2020" },
                    { 9, 896816, "Oldsmobile", "Cutlass", "1967" },
                    { 17, 978371, "Chevrolet", "Corvette Sting Ray", "1963" },
                    { 8, 318823, "Acura", "NSX", "1990" },
                    { 7, 318823, "Mercedes-benz", "SL-63", "2019" },
                    { 6, 757023, "Dodge", "Viper", "1995" },
                    { 5, 277347, "Ford", "Mustang", "1966" },
                    { 4, 427132, "Porsche", "Macan", "2022" },
                    { 3, 324822, "GMC", "Suburban", "2014" },
                    { 2, 324822, "BMW", "Z4", "2008" },
                    { 1, 324822, "Tesla", "Model X", "2020" },
                    { 10, 158000, "Shelby", "G.T. 350", "2020" },
                    { 18, 978371, "Aston Martin", "DB4 GT Zagato", "1960" }
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
