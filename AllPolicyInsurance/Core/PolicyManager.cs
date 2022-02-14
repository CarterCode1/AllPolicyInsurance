using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AllPolicyInsurance.DataLayer;

namespace AllPolicyInsurance.Core
{
    public class PolicyManager : IPolicyManager
    {

        private readonly ILogger<PolicyManager> _logger;
        private IPolicyRepository _policyRepository;

        public PolicyManager(ILogger<PolicyManager> logger, IPolicyRepository policyRepository, IMessageService messageService)
        {
            _logger = logger;
            _policyRepository = policyRepository;
        }

        public async Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            var createdPolicy = await _policyRepository.CreateInsurancePolicy(insurancePolicy);
            return createdPolicy;

        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            return _policyRepository.DeletePolicy(policy);
        }

        public async Task<IList<InsurancePolicy>> GetPolicies()
        {
            return await _policyRepository.GetPolicies();
        }

        public async Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            return await _policyRepository.GetPoliciesByDriversLiscense(liscenseNumber);
        }

        public async Task<InsurancePolicy> GetPolicyById(int id)
        {
            return await _policyRepository.GetPolicyById(id);
        }
    }
}
