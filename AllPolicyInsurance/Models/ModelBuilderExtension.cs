using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AllPolicyInsurance.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<int> policyIdList = new List<int>();

            var random = new Random();

            while (policyIdList.Count < 12 )
            {
                var tempPolicyId = random.Next(100000, 1000000);
                if(!policyIdList.Contains(tempPolicyId))
                {
                    policyIdList.Add(tempPolicyId);
                }
            }
            
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, InsurancePolicyId = policyIdList[0], City = "Cincinatti", Street = "123 Main St", State = "OH", PostalCode = "45215" },
                new Address { AddressId = 2, InsurancePolicyId = policyIdList[1], City = "Cincinatti", Street = "77 Elm Avenue", State = "OH", PostalCode = "45203" },
                new Address { AddressId = 3, InsurancePolicyId = policyIdList[2],  City = "Las Vegas", Street = "702 Flamingo Rd", State = "NV", PostalCode = "89105" },
                new Address { AddressId = 4, InsurancePolicyId = policyIdList[3],  City = "Henderson", Street = "21 Tropicana Ave", State = "NV", PostalCode = "89119" },
                new Address { AddressId = 5, InsurancePolicyId = policyIdList[4],  City = "San Fransisco", Street = "88 Haight St", State = "CA", PostalCode = "94117" },
                new Address { AddressId = 6, InsurancePolicyId = policyIdList[5],  City = "San Fransisco", Street = "420 Ashbury", State = "CA", PostalCode = "94117" },
                new Address { AddressId = 7, InsurancePolicyId = policyIdList[6],  City = "Oakland", Street = "570 Pharcyde Lane", State = "CA", PostalCode = "94604" },
                new Address { AddressId = 8, InsurancePolicyId = policyIdList[7],  City = "Oakland", Street = "E. 40 Major Way ", State = "CA", PostalCode = "94616" },
                new Address { AddressId = 9, InsurancePolicyId = policyIdList[8], City = "Los Angeles", Street = "88 Pacific Overlook Blvd", State = "CA", PostalCode = "90210" },
                new Address { AddressId = 10, InsurancePolicyId = policyIdList[9], City = "Newport", Street = "8 Mamba Street", State = "CA", PostalCode = "90004" },
                new Address { AddressId = 11, InsurancePolicyId = policyIdList[10], City = "Brooklyn", Street = "123 Fulton Street", State = "NY", PostalCode = "11211" },
                new Address { AddressId = 12, InsurancePolicyId = policyIdList[11], City = "Brooklyn", Street = "1120 Flatbush Ave ", State = "NY", PostalCode = "11206" }
                );

            modelBuilder.Entity<InsurancePolicy>().HasData(
                new InsurancePolicy()
                {
                    PolicyId  = policyIdList[0],
                    EffectiveDate = DateTime.Now.AddDays(-30),
                    ExpirationDate = DateTime.Now.AddYears(2),
                    FirstName = "Joe",
                    LastName = "Burrow",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 350.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[1],
                    EffectiveDate = DateTime.Now.AddMonths(-10),
                    ExpirationDate = DateTime.Now.AddYears(3),
                    FirstName = "Ja'Marr",
                    LastName = "Chase",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 225.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[2],
                    EffectiveDate = DateTime.Now.AddYears(-8),
                    ExpirationDate = DateTime.Now.AddYears(-4),
                    FirstName = "Mark",
                    LastName = "Stone",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 145.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[3],
                    EffectiveDate = DateTime.Now.AddMonths(-27),
                    ExpirationDate = DateTime.Now.AddYears(-1),
                    FirstName = "Larry",
                    LastName = "Johnson",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 225.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[4],
                    EffectiveDate = DateTime.Now.AddMonths(-12),
                    ExpirationDate = DateTime.Now.AddYears(3),
                    FirstName = "Steph",
                    LastName = "Curry",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 315.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[5],
                    EffectiveDate = DateTime.Now.AddDays(-30),
                    ExpirationDate = DateTime.Now.AddYears(5),
                    FirstName = "Draymond",
                    LastName = "Green",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 200.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[6],
                    EffectiveDate = DateTime.Now.AddYears(-8),
                    ExpirationDate = DateTime.Now.AddMonths(-20),
                    FirstName = "Andrew",
                    LastName = "Wiggins",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 225.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[7],
                    EffectiveDate = DateTime.Now.AddMonths(-15),
                    ExpirationDate = DateTime.Now.AddYears(3),
                    FirstName = "Debo",
                    LastName = "Samuel",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 345.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[8],
                    EffectiveDate = DateTime.Now.AddYears(-6),
                    ExpirationDate = DateTime.Now.AddYears(-1),
                    FirstName = "Cooper",
                    LastName = "Kupp",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 65.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[9],
                    EffectiveDate = DateTime.Now.AddYears(-6),
                    ExpirationDate = DateTime.Now.AddYears(-1),
                    FirstName = "Kobe",
                    LastName = "Bryant",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 65.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[10],
                    EffectiveDate = DateTime.Now.AddDays(-15),
                    ExpirationDate = DateTime.Now.AddMonths(44),
                    FirstName = "Kyrie",
                    LastName = "Irving",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 311.0M
                },
                new InsurancePolicy()
                {
                    PolicyId = policyIdList[11],
                    EffectiveDate = DateTime.Now.AddMonths(-17),
                    ExpirationDate = DateTime.Now.AddMonths(30),
                    FirstName = "Kevin",
                    LastName = "Durant",
                    DriversLicenseNumber = random.Next(0, 100000000).ToString("D8"),
                    PremiumPrice = 420.0M
                }
            );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, InsurancePolicyId = policyIdList[0], Year = "2020", Make = "Tesla", Model = "Model X" },
                new Vehicle { VehicleId = 2, InsurancePolicyId = policyIdList[0], Year = "2014", Make = "GMC", Model = "Suburban" },
                new Vehicle { VehicleId = 3, InsurancePolicyId = policyIdList[0], Year = "2008", Make = "BMW", Model = "Z4" },      
                new Vehicle { VehicleId = 4, InsurancePolicyId = policyIdList[1], Year = "2022", Make = "Porsche", Model = "Macan" },
                new Vehicle { VehicleId = 5, InsurancePolicyId = policyIdList[2], Year = "1966", Make = "Ford", Model = "Mustang" },               
                new Vehicle { VehicleId = 6, InsurancePolicyId = policyIdList[3], Year = "1995", Make = "Dodge", Model = "Viper" },
                new Vehicle { VehicleId = 7, InsurancePolicyId = policyIdList[4], Year = "2019", Make = "Mercedes-benz", Model = "SL-63" },
                new Vehicle { VehicleId = 8, InsurancePolicyId = policyIdList[4], Year = "1990", Make = "Acura", Model = "NSX" },
                new Vehicle { VehicleId = 9, InsurancePolicyId = policyIdList[5], Year = "1967", Make = "Oldsmobile", Model = "Cutlass" },
                new Vehicle { VehicleId = 10, InsurancePolicyId = policyIdList[6], Year = "2020", Make = "Shelby", Model = "G.T. 350" },
                new Vehicle { VehicleId = 11, InsurancePolicyId = policyIdList[7], Year = "2021", Make = "BMW", Model = "M6" },
                new Vehicle { VehicleId = 12, InsurancePolicyId = policyIdList[8], Year = "1993", Make = "Chevrolet", Model = "Tahoe" },
                new Vehicle { VehicleId = 13, InsurancePolicyId = policyIdList[9], Year = "2020", Make = "McLaren", Model = "F1" },
                new Vehicle { VehicleId = 14, InsurancePolicyId = policyIdList[10], Year = "2022", Make = "Lamborghini", Model = "Huracan" },
                new Vehicle { VehicleId = 15, InsurancePolicyId = policyIdList[11], Year = "2021", Make = "Tesla", Model = "Model X" }
                new Vehicle { VehicleId = 16, InsurancePolicyId = policyIdList[11], Year = "2020", Make = "Porsche", Model = "911 Turbo S" }
                new Vehicle { VehicleId = 17, InsurancePolicyId = policyIdList[11], Year = "1963", Make = "Chevrolet", Model = "Corvette Sting Ray" }
                new Vehicle { VehicleId = 18, InsurancePolicyId = policyIdList[11], Year = "1960", Make = "Aston Martin", Model = "DB4 GT Zagato" } 
                
                );  
        }
    }
}
