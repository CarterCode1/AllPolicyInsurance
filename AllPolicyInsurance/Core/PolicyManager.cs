using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AllPolicyInsurance.Core
{
    public class PolicyManager : IPolicyManager
    {

        private readonly ILogger<PolicyManager> _logger;
        private IPolicyManager _policyManager;

        public PolicyManager(ILogger<PolicyManager> logger, IPolicyManager policyManager, IMessageService messageService)
        {
            _logger = logger;
            _policyManager = policyManager;
        }

        public Task<InsurancePolicy> CreateInsurancePolicy(PolicyDTO policyDTO)
        {
            throw new System.NotImplementedException();
        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<InsurancePolicy>> GetPolicies()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            throw new System.NotImplementedException();
        }

        public Task<InsurancePolicy> GetPolicyById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
