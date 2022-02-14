using System;
using System.Collections.Generic;

namespace AllPolicyInsurance.Dto
{
    public class PolicyRequestDTO
    {

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriversLicenseNumber { get; set; }
        public decimal PremiumPrice { get; set; }
        public ICollection<VehicleDTO> Vehicles { get; set; }

        public AddressDTO Address { get; set; }

    }
}
