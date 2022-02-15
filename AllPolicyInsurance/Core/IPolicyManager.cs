
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllPolicyInsurance.Core
{
    public interface IPolicyManager
    {
        Task<IList<InsurancePolicy>> GetPolicies();
        Task<InsurancePolicy> GetPolicyById(int id);
        Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber, string sortOrder, bool isExpired = false);
        Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy);
        Task DeletePolicy(InsurancePolicy policy);
    }
}
