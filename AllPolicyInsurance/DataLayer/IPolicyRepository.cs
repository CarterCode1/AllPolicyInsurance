
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;

namespace AllPolicyInsurance.DataLayer
{
    public interface IPolicyRepository
    {
        IList<InsurancePolicy> GetPolicies();
        InsurancePolicy GetPolicyById(int id);
        IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber);
        InsurancePolicy CreateInsurancePolicy(PolicyDTO policyDTO);
        void DeletePolicy(InsurancePolicy policy);
    }
}