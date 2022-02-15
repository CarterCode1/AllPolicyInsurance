using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllPolicyInsurance.Dto
{
    public class PolicyRequestDTO
    {
        [Required]
        public DateTime EffectiveDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Invalid {0}. Numbers only required")]
        [StringLength(8, ErrorMessage = "Invalid {0} format")]
        public string DriversLicenseNumber { get; set; }

        [Required]
        public decimal PremiumPrice { get; set; }

        [Required]
        public IList<VehicleDTO> Vehicles { get; set; }

        [Required]
        public AddressDTO Address { get; set; }

    }
}
