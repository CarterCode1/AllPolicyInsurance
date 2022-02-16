
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AllPolicyInsurance.Core
{
    public interface IPolicyManager
    {
        Task<IList<InsurancePolicy>> GetPolicies();
        Task<InsurancePolicy> GetPolicyById(int id, string licenseNumber);
        Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber, string sortOrder, bool isExpired = false);
        Task<CreatePolicyResponse> CreateInsurancePolicy(InsurancePolicy insurancePolicy);
        Task DeletePolicy(InsurancePolicy policy);
    }
}
