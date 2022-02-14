using AllPolicyInsurance.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllPolicyInsurance.Models
{
    public class InsurancePolicy
    {
        public InsurancePolicy()
        {
        }

        public InsurancePolicy(PolicyRequest policyDTO)
        {
            EffectiveDate = policyDTO.EffectiveDate;
            FirstName = policyDTO.FirstName;
            LastName = policyDTO.LastName;
            DriversLicenseNumber = policyDTO.DriversLicenseNumber;
            PremiumPrice = policyDTO.PremiumPrice;
            Vehicles = new List<Vehicle>() {
           new Vehicle()
            {
                Make = policyDTO.VehicleMake,
                Model = policyDTO.VehicleModel,
                Year = policyDTO.VehicleYear,
            }
            };
            Address = new Address()
            {
                Street = policyDTO.Street,
                City = policyDTO.City,
                State = policyDTO.State,
                PostalCode = policyDTO.PostalCode,
            };
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DriversLicenseNumber { get; set; }

        public decimal PremiumPrice { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual Address Address { get; set; }
    }
}
