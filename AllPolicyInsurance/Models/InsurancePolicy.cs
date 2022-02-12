using AllPolicyInsurance.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllPolicyInsurance.Models
{
    public class InsurancePolicy
    {
        public InsurancePolicy()
        {
        }

        public InsurancePolicy(PolicyDTO policyDTO)
        {
            Id = Guid.NewGuid();
            EffectiveDate = policyDTO.EffectiveDate;
            FirstName = policyDTO.FirstName;
            LastName = policyDTO.LastName;
            DriversLicenseNumber = policyDTO.DriversLicenseNumber;
            PremiumPrice = policyDTO.PremiumPrice;
            Vehicle = new Vehicle()
            {
                Make = policyDTO.VehicleMake,
                Model = policyDTO.VehicleModel,
                Year = policyDTO.VehicleYear,
            };
            Address = new Address()
            {
                Street = policyDTO.Street,
                City = policyDTO.City,
                PostalCode = policyDTO.PostalCode,
            };
        }

        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PolicyId { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DriversLicenseNumber { get; set; }

        public byte VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public byte AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal PremiumPrice { get; set; }
    }
}
