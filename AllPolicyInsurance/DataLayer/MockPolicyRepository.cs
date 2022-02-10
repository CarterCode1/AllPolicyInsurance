using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AllPolicyInsurance.DataLayer
{
    public class MockPolicyRepository : IPolicyRepository
    {

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>()
        {
            new InsurancePolicy()
            {
                Id = Guid.NewGuid(),
                EffectiveDate = DateTime.Now,
                FirstName = "Joe",
                LastName = "Burrow",
                DriversLicenseNumber = "1234567",
                Vehicle = new Vehicle() { Year = 2020, Make ="Tesla", Model="Model Y"},

                Address = new Address() { City ="Cincinatti", Street = "123 Main St", State="OH",PostalCode ="45215"},
                ExpirationDate = DateTime.Now.AddYears(4),
                PremiumPrice = 200.0M
            },

            new InsurancePolicy()
            {
                Id = Guid.NewGuid(),
                EffectiveDate = DateTime.Now,
                FirstName = "Ja'Marr",
                LastName = "Chase",
                DriversLicenseNumber = "7654321",
                Vehicle = new Vehicle() { Year = 2022, Make ="Porsche", Model="Macan"},

                Address = new Address() { City ="Cincinatti", Street = "456 Main St", State="OH",PostalCode ="45215"},
                ExpirationDate = DateTime.Now.AddYears(4),
                PremiumPrice = 250.0M
            },
        };
        public InsurancePolicy CreateInsurancePolicy(InsurancePolicy newInsurancePolicy)
        {
            newInsurancePolicy.Id = Guid.NewGuid();
            _insurancePolicies.Add(newInsurancePolicy);
            return newInsurancePolicy;
        }

        public void DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            var matchedPolicies = from policy in _insurancePolicies where policy.DriversLicenseNumber == liscenseNumber select policy;
            return matchedPolicies.ToList();
        }
    }
}
