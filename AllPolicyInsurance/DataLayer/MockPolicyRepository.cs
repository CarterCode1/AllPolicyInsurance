using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Dto;

namespace AllPolicyInsurance.DataLayer
{
    public class MockPolicyRepository : IPolicyRepository
    {

        private List<InsurancePolicy> _insurancePolicies = new List<InsurancePolicy>()
        {
            new InsurancePolicy()
            {
                PolicyId = 1234,
                EffectiveDate = DateTime.Now,
                FirstName = "Joe",
                LastName = "Burrow",
                DriversLicenseNumber = "1234567",

                //Vehicles.Add( new Vehicle() { Year = 2020, Make ="Tesla", Model="Model Y"} ),

                Address = new Address() { City ="Cincinatti", Street = "123 Main St", State="OH",PostalCode ="45215"},
                ExpirationDate = DateTime.Now.AddYears(4),
                PremiumPrice = 200.0M
            },

            new InsurancePolicy()
            {
                PolicyId = 8888123,
                EffectiveDate = DateTime.Now,
                FirstName = "Ja'Marr",
                LastName = "Chase",
                DriversLicenseNumber = "7654321",
               //Vehicle = new Vehicle() { Year = 2022, Make ="Porsche", Model="Macan"},

                Address = new Address() { City ="Cincinatti", Street = "456 Main St", State="OH",PostalCode ="45215"},
                ExpirationDate = DateTime.Now.AddYears(4),
                PremiumPrice = 250.0M
            },
        };

        public Task<IList<InsurancePolicy>> GetPolicies()
        {
            return Task.FromResult< IList <InsurancePolicy>>( _insurancePolicies);
        }
        public  Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            _insurancePolicies.Add(insurancePolicy);

            return Task.FromResult<InsurancePolicy> (insurancePolicy);
        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public Task<InsurancePolicy> GetPolicyById(int id, string liscenseNumber)
        {
            return Task.FromResult<InsurancePolicy>(
                _insurancePolicies.SingleOrDefault(x => x.PolicyId == id));
        }

        public  Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber, string sortOrder, bool isExpired = false)
        {
            return Task.FromResult<IList<InsurancePolicy>>(
                _insurancePolicies.Where(p => p.DriversLicenseNumber == liscenseNumber).ToList());
        }
    }
}
