using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using AllPolicyInsurance.Dto;

namespace AllPolicyInsurance.DataLayer
{
    public class MockPolicyRepository : IPolicyRepository
    {

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>()
        {
            new InsurancePolicy()
            {
                Id = Guid.NewGuid(),
                PolicyId = 1234,
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
                PolicyId = 8888123,
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

        public IList<InsurancePolicy> GetPolicies()
        {
            return _insurancePolicies;
        }
        public InsurancePolicy CreateInsurancePolicy(PolicyDTO policy)
        {
            var newInsurancePolicy = new InsurancePolicy(policy);
            _insurancePolicies.Add(newInsurancePolicy);

            return newInsurancePolicy;
        }

        public void DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            return _insurancePolicies.SingleOrDefault(x => x.PolicyId == id);
        }

        public IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            return _insurancePolicies.Where(p => p.DriversLicenseNumber == liscenseNumber).ToList();
        }
    }
}
