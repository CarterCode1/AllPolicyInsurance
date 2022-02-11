
using AllPolicyInsurance.Models;
using System.Collections.Generic;

namespace AllPolicyInsurance.DataLayer
{
    public interface IPolicyRepository
    {
        IList<InsurancePolicy> GetPolicies();
        InsurancePolicy GetPolicyById(int id);
        IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber);
        InsurancePolicy CreateInsurancePolicy(InsurancePolicy newInsurancePolicy);
        void DeletePolicy(InsurancePolicy policy);
    }
}