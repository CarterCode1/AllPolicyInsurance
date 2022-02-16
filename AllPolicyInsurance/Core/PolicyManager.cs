using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using AllPolicyInsurance.DataLayer;
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;


namespace AllPolicyInsurance.Core
{
    public class PolicyManager : RegulatoryManager, IPolicyManager 
    {

        private readonly ILogger<PolicyManager> _logger;
        private readonly IConfiguration _configuration;
        private  IPolicyRepository _policyRepository;
        private IMessageService _messageService;
        private readonly IMapper _mapper;


        public PolicyManager(ILogger<PolicyManager> logger, IConfiguration configuration, IPolicyRepository policyRepository, IMapper mapper, IMessageService messageService)
        {
            _logger = logger;
            _configuration = configuration;
            _policyRepository = policyRepository;
            _messageService = messageService;
            _mapper = mapper; 
        }

        public async Task<CreatePolicyResponse> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            
            if(!VerifyEffectiveDate(insurancePolicy))
            {
                return new CreatePolicyResponse()
                {
                    IsSuccess = false,
                    Message = DeclinedExplanation,
                    Policy = _mapper.Map<PolicyDTO>(insurancePolicy),
                };
            }

            if(!VerifyClassicVehicle(insurancePolicy))
            {
                return new CreatePolicyResponse()
                {
                    IsSuccess = false,
                    Message = DeclinedExplanation,
                    Policy = _mapper.Map<PolicyDTO>(insurancePolicy),
                };
            }

            if(!VerifyStateRegulations(insurancePolicy))
            {
                return new CreatePolicyResponse() { 
                    IsSuccess = false, 
                    Message = DeclinedExplanation,
                    Policy = _mapper.Map<PolicyDTO>(insurancePolicy),
                };    
            }

            var createdPolicy = await _policyRepository.CreateInsurancePolicy(insurancePolicy);

            //var isPublishSuccess =  _messageService.PublishNewPolicy(createdPolicy);

            return new CreatePolicyResponse()
            {
                IsSuccess = true,
                Policy = _mapper.Map<PolicyDTO>(insurancePolicy),
                Message = null,
            };
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
        

        private bool VerifyEffectiveDate(InsurancePolicy insurancePolicy)
        {
            if(insurancePolicy.EffectiveDate < DateTime.Now.AddDays(30))
            {
                DeclinedExplanation = "Effective Date must be 30 days in the future.";
                return false;
            }
            return true;
        }

        private bool VerifyClassicVehicle(InsurancePolicy insurancePolicy)
        {
            foreach (Vehicle vehicle in insurancePolicy.Vehicles)
            {
                if (int.Parse(vehicle.Year) > int.Parse(_configuration["ClassicVehicle"]))
                {
                    DeclinedExplanation = ($"Vehicle {vehicle.Make} {vehicle.Model} is ineligible for coverage due to it not meeting the requirements of a Classic Vehicle.");
                    return false;
                }
            }
            return true;
        }
    }
}
