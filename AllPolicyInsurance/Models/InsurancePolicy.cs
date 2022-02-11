using System;

namespace AllPolicyInsurance.Models
{
    public class InsurancePolicy
    {
        public Guid Id { get; set; }
        public int PolicyId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DriversLicenseNumber { get; set; }
        public Vehicle Vehicle { get; set; }
        public Address Address { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Decimal PremiumPrice { get; set; }
    }
}
