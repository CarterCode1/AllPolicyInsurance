using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Core;
using AutoMapper;
using AllPolicyInsurance.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace AllPolicyInsurance.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private IPolicyManager _policyManager;
        private readonly IMapper _mapper;

        public PolicyController(ILogger<PolicyController> logger,  IMapper mapper, IPolicyManager policyManager)
        {
            _logger = logger;
            _mapper = mapper;
            _policyManager = policyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            try
            {
                var policies = await _policyManager.GetPolicies();
                var policyDTO = _mapper.Map<List<PolicyDTO>>(policies);

                return Ok(policyDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has occurred on GetPolicies endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }
        }

        [HttpGet("id/{id}/license/{license}")]
        public async Task<IActionResult> GetPoliciesById(int id, string license)
        {
            try
            {

                var policy = await _policyManager.GetPolicyById(id, license);
                var policyDTO = _mapper.Map<PolicyDTO>(policy);

                if (policyDTO != null)
                {
                    return Ok(policyDTO);
                }
                return NotFound($"Policy with Id: {id} was not found.");

            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has occurred on GetPolicyById endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }
        }

        [HttpGet("license/{license}")]
        public async Task<IActionResult> GetPoliciesByDriversLiscense(string license, string sortOrder, bool isExpired = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(license))
                {
                    return BadRequest("Drivers license number is required.");
                }

                if (!int.TryParse(license, out _ ))
                {
                    return BadRequest("Drivers license is required to in number format.");
                }

                var policies = await _policyManager.GetPoliciesByDriversLiscense(license, sortOrder, isExpired);
                var policyDTO = _mapper.Map<List<PolicyDTO>>(policies);

                if (policyDTO.Any())
                {
                    return Ok(policyDTO);
                }
                return NotFound($"Policy with Drivers Liscense {license} was not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has occurred on GetPoliciesByDriversLiscense endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyRequestDTO policyRequestDTO)
        {
            try
            {
                var createPolicyResponse = await _policyManager.CreateInsurancePolicy(_mapper.Map<InsurancePolicy>(policyRequestDTO));

                if (createPolicyResponse.IsSuccess == true)
                {
                    var createdPolicyDTO = createPolicyResponse.Policy;
                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicyDTO.PolicyId, createdPolicyDTO);
                }

                return BadRequest(createPolicyResponse.Message);


            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has occurred in CreatePolicy endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }

        }
    }
}
