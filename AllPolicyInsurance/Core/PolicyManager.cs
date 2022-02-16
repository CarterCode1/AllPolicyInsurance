using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AllPolicyInsurance.DataLayer;
using System.Net.Http;
using System.Net;
using System;

namespace AllPolicyInsurance.Core
{
    public class PolicyManager : RegulatoryManager, IPolicyManager 
    {

        private readonly ILogger<PolicyManager> _logger;
        private IPolicyRepository _policyRepository;

        public PolicyManager(ILogger<PolicyManager> logger, IPolicyRepository policyRepository, IMessageService messageService)
        {
            _logger = logger;
            _policyRepository = policyRepository;
        }

        public async Task<Tuple<bool , InsurancePolicy, string >> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            string message = null;
            
            if(VerifyStateRegulations(insurancePolicy))
            {
                return new Tuple<bool, InsurancePolicy, string>(false, insurancePolicy, DeclinedExplanation);
            }

            var createdPolicy = await _policyRepository.CreateInsurancePolicy(insurancePolicy);
            return new Tuple<bool, InsurancePolicy, string> (true, createdPolicy, message);

        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            return _policyRepository.DeletePolicy(policy);
        }

        public async Task<IList<InsurancePolicy>> GetPolicies()
        {
            return await _policyRepository.GetPolicies();
        }

        public async Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber, string sortOrder, bool isExpired = false)
        {
            return await _policyRepository.GetPoliciesByDriversLiscense(liscenseNumber, sortOrder, isExpired);
        }

        public async Task<InsurancePolicy> GetPolicyById(int id)
        {
            return await _policyRepository.GetPolicyById(id);
        }
    }
}
