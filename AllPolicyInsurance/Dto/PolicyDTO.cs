using System;

namespace AllPolicyInsurance.Dto
{
    public class PolicyDTO
    {

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public int VehicleYear { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public decimal PremiumPrice { get; set; }
    }
}
