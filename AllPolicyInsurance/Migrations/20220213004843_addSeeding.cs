using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPolicyInsurance.Migrations
{
    public partial class addSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "City", "PostalCode", "State", "Street" },
                values: new object[,]
                {
                    { (byte)1, "Cincinatti", "45215", "OH", "123 Main St" },
                    { (byte)11, "Brooklyn", "11211", "NY", "123 Fulton Street" },
                    { (byte)10, "Newport", "90004", "CA", "8 Mamba Street" },
                    { (byte)9, "Los Angeles", "90210", "CA", "88 Pacific Overlook Blvd" },
                    { (byte)8, "Oakland", "94616", "CA", "E. 40 Major Way " },
                    { (byte)7, "Oakland", "94604", "CA", "570 Pharcyde Lane" },
                    { (byte)12, "Brooklyn", "11206", "NY", "1120 Flatbush Ave " },
                    { (byte)5, "San Fransisco", "94117", "CA", "88 Haight St" },
                    { (byte)4, "Henderson", "89119", "NV", "21 Tropicana Ave" },
                    { (byte)3, "Las Vegas", "89105", "NV", "702 Flamingo Rd" },
                    { (byte)2, "Cincinatti", "45203", "OH", "77 Elm Avenue" },
                    { (byte)6, "San Fransisco", "94117", "CA", "420 Ashbury" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { (byte)10, "McLaren", "F1", 2020 },
                    { (byte)9, "Chevrolet", "Tahoe", 1993 },
                    { (byte)8, "BMW", "M6", 2021 },
                    { (byte)7, "Shelby", "G.T. 350", 2020 },
                    { (byte)6, "Oldsmobile", "Cutlass", 1967 },
                    { (byte)4, "Dodge", "Viper", 1995 },
                    { (byte)3, "Ford", "Mustang", 1966 },
                    { (byte)2, "Porsche", "Macan", 2022 },
                    { (byte)1, "Tesla", "Model X", 2020 },
                    { (byte)11, "Lamborghini", "Huracan", 2022 },
                    { (byte)5, "Mercedes-benz", "SL-63", 2019 },
                    { (byte)12, "Tesla", "Model X", 2021 }
                });

            migrationBuilder.InsertData(
                table: "InsurancePolicies",
                columns: new[] { "Id", "AddressId", "DriversLicenseNumber", "EffectiveDate", "ExpirationDate", "FirstName", "LastName", "PolicyId", "PremiumPrice", "VehicleId" },
                values: new object[,]
                {
                    { new Guid("9ba575e0-4364-49f2-8a24-301f871de0a1"), (byte)1, "05012816", new DateTime(2022, 1, 13, 16, 48, 43, 352, DateTimeKind.Local).AddTicks(3831), new DateTime(2024, 2, 12, 16, 48, 43, 354, DateTimeKind.Local).AddTicks(9059), "Joe", "Burrow", 370600, 350.0m, (byte)1 },
                    { new Guid("9cbf58ab-3142-464b-a25d-5db51520972f"), (byte)2, "58143643", new DateTime(2021, 4, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1226), new DateTime(2025, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1244), "Ja'Marr", "Chase", 506435, 225.0m, (byte)2 },
                    { new Guid("b70062b6-56ab-4374-98fd-9261e1b139c7"), (byte)3, "88416272", new DateTime(2014, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1259), new DateTime(2018, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1261), "Mark", "Stone", 648210, 145.0m, (byte)3 },
                    { new Guid("5923aa15-958e-46cf-933b-5d7d7dabe023"), (byte)4, "67530787", new DateTime(2019, 11, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1267), new DateTime(2021, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1269), "Larry", "Johnson", 884759, 225.0m, (byte)4 },
                    { new Guid("00390dae-ab04-435a-8d03-d1d667e0913c"), (byte)5, "82232261", new DateTime(2021, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1273), new DateTime(2025, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1275), "Steph", "Curry", 850485, 315.0m, (byte)5 },
                    { new Guid("21985b7d-6bdf-48c0-90dd-84211b020eca"), (byte)6, "58677291", new DateTime(2022, 1, 13, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1279), new DateTime(2027, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1281), "Draymond", "Green", 340004, 200.0m, (byte)6 },
                    { new Guid("0f2d629d-9382-4892-bb00-66fb1b0cd02a"), (byte)7, "58401113", new DateTime(2014, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1286), new DateTime(2020, 6, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1288), "Andrew", "Wiggins", 485716, 225.0m, (byte)7 },
                    { new Guid("e347c6cf-66a2-4598-8962-e8cc01c4b49b"), (byte)8, "23047374", new DateTime(2020, 11, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1298), new DateTime(2025, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1300), "Debo", "Samuel", 344132, 345.0m, (byte)8 },
                    { new Guid("865369c4-b0aa-4181-8351-a0216085b9ec"), (byte)9, "50028651", new DateTime(2016, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1305), new DateTime(2021, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1307), "Cooper", "Kupp", 965105, 65.0m, (byte)9 },
                    { new Guid("e166e525-e2b0-4faf-b0fb-272265b0b927"), (byte)10, "39527559", new DateTime(2016, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1312), new DateTime(2021, 2, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1314), "Kobe", "Bryant", 140236, 65.0m, (byte)10 },
                    { new Guid("eb1d4a1d-cf7d-44b4-98b7-3f4ba75e6c16"), (byte)11, "15182572", new DateTime(2022, 1, 28, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1318), new DateTime(2025, 10, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1320), "Kyrie", "Irving", 766703, 311.0m, (byte)11 },
                    { new Guid("684caae3-2647-4554-a6d5-6a9b1c590a3d"), (byte)12, "06884140", new DateTime(2020, 9, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1324), new DateTime(2024, 8, 12, 16, 48, 43, 355, DateTimeKind.Local).AddTicks(1327), "Kevin", "Durant", 962573, 420.0m, (byte)12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("00390dae-ab04-435a-8d03-d1d667e0913c"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("0f2d629d-9382-4892-bb00-66fb1b0cd02a"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("21985b7d-6bdf-48c0-90dd-84211b020eca"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("5923aa15-958e-46cf-933b-5d7d7dabe023"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("684caae3-2647-4554-a6d5-6a9b1c590a3d"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("865369c4-b0aa-4181-8351-a0216085b9ec"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("9ba575e0-4364-49f2-8a24-301f871de0a1"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("9cbf58ab-3142-464b-a25d-5db51520972f"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("b70062b6-56ab-4374-98fd-9261e1b139c7"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("e166e525-e2b0-4faf-b0fb-272265b0b927"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("e347c6cf-66a2-4598-8962-e8cc01c4b49b"));

            migrationBuilder.DeleteData(
                table: "InsurancePolicies",
                keyColumn: "Id",
                keyValue: new Guid("eb1d4a1d-cf7d-44b4-98b7-3f4ba75e6c16"));

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "AddressId",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)9);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)10);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: (byte)12);
        }
    }
}
