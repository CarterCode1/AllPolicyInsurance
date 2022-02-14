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
                    { 329033, "88334554", new DateTime(2022, 1, 15, 12, 25, 46, 381, DateTimeKind.Local).AddTicks(6384), new DateTime(2024, 2, 14, 12, 25, 46, 383, DateTimeKind.Local).AddTicks(9156), "Joe", "Burrow", 350.0m },
                    { 398210, "60141428", new DateTime(2021, 4, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(665), new DateTime(2025, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(681), "Ja'Marr", "Chase", 225.0m },
                    { 553982, "04092046", new DateTime(2014, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(696), new DateTime(2018, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(699), "Mark", "Stone", 145.0m },
                    { 162048, "73824913", new DateTime(2019, 11, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(751), new DateTime(2021, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(754), "Larry", "Johnson", 225.0m },
                    { 457727, "34180223", new DateTime(2021, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(757), new DateTime(2025, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(759), "Steph", "Curry", 315.0m },
                    { 934795, "99503409", new DateTime(2022, 1, 15, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(763), new DateTime(2027, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(765), "Draymond", "Green", 200.0m },
                    { 555816, "52347333", new DateTime(2014, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(768), new DateTime(2020, 6, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(770), "Andrew", "Wiggins", 225.0m },
                    { 988010, "54106900", new DateTime(2020, 11, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(774), new DateTime(2025, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(776), "Debo", "Samuel", 345.0m },
                    { 539139, "21642779", new DateTime(2016, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(780), new DateTime(2021, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(782), "Cooper", "Kupp", 65.0m },
                    { 716879, "06269112", new DateTime(2016, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(786), new DateTime(2021, 2, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(788), "Kobe", "Bryant", 65.0m },
                    { 596124, "06023789", new DateTime(2022, 1, 30, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(791), new DateTime(2025, 10, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(793), "Kyrie", "Irving", 311.0m },
                    { 661511, "95007774", new DateTime(2020, 9, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(796), new DateTime(2024, 8, 14, 12, 25, 46, 384, DateTimeKind.Local).AddTicks(799), "Kevin", "Durant", 420.0m }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "InsurancePolicyId", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { 1, "Cincinatti", 329033, "45215", "OH", "123 Main St" },
                    { 2, "Cincinatti", 398210, "45203", "OH", "77 Elm Avenue" },
                    { 11, "Brooklyn", 596124, "11211", "NY", "123 Fulton Street" },
                    { 3, "Las Vegas", 553982, "89105", "NV", "702 Flamingo Rd" },
                    { 4, "Henderson", 162048, "89119", "NV", "21 Tropicana Ave" },
                    { 10, "Newport", 716879, "90004", "CA", "8 Mamba Street" },
                    { 5, "San Fransisco", 457727, "94117", "CA", "88 Haight St" },
                    { 6, "San Fransisco", 934795, "94117", "CA", "420 Ashbury" },
                    { 12, "Brooklyn", 661511, "11206", "NY", "1120 Flatbush Ave " },
                    { 7, "Oakland", 555816, "94604", "CA", "570 Pharcyde Lane" },
                    { 9, "Los Angeles", 539139, "90210", "CA", "88 Pacific Overlook Blvd" },
                    { 8, "Oakland", 988010, "94616", "CA", "E. 40 Major Way " }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "InsurancePolicyId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 11, 596124, "Lamborghini", "Huracan", "2022" },
                    { 10, 716879, "McLaren", "F1", "2020" },
                    { 9, 539139, "Chevrolet", "Tahoe", "1993" },
                    { 6, 934795, "Oldsmobile", "Cutlass", "1967" },
                    { 7, 555816, "Shelby", "G.T. 350", "2020" },
                    { 5, 457727, "Mercedes-benz", "SL-63", "2019" },
                    { 4, 162048, "Dodge", "Viper", "1995" },
                    { 3, 553982, "Ford", "Mustang", "1966" },
                    { 2, 398210, "Porsche", "Macan", "2022" },
                    { 1, 329033, "Tesla", "Model X", "2020" },
                    { 8, 988010, "BMW", "M6", "2021" },
                    { 12, 661511, "Tesla", "Model X", "2021" }
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
