using AllPolicyInsurance.Models;
using System.Collections.Generic;

namespace AllPolicyInsurance.DataLayer
{
    public class PolicyRepository : IPolicyRepository
    {
        public InsurancePolicy CreateInsurancePolicy(InsurancePolicy newInsurancePolicy)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public IList<InsurancePolicy> GetPolicies()
        {
            throw new System.NotImplementedException();
        }

        public IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            throw new System.NotImplementedException();
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
