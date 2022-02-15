﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Core;
using AutoMapper;
using AllPolicyInsurance.Models;
using System;

namespace AllPolicyInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private IPolicyManager _policyManager;
        private readonly IMapper _mapper;

        public PolicyController(ILogger<PolicyController> logger, IMapper mapper, IPolicyManager policyManager)
        {
            _mapper = mapper;
            _logger = logger;
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

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetPoliciesById(int id)
        {
            try
            {

                var policy = await _policyManager.GetPolicyById(id);
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

        [HttpGet("liscence/{liscence}")]
        public async Task<IActionResult> GetPoliciesByDriversLiscense(string liscence, string sortOrder , bool isExpired = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(liscence))
                {
                    return BadRequest("Drivers Liscence number is required.");
                }

                if(!int.TryParse(liscence, out _))
                {
                    return BadRequest("Drivers Liscence is required to in number format.");
                }
                var t = sortOrder;
                var policies = await _policyManager.GetPoliciesByDriversLiscense(liscence, sortOrder, isExpired);
                var policyDTO = _mapper.Map<List<PolicyDTO>>(policies);

                if (policyDTO.Any())
                {
                    return Ok(policyDTO);
                }
                return NotFound($"Policy with Drivers Liscense {liscence} was not found.");
            }
            catch(Exception ex)
            {
                _logger.LogError("An exception has occurred on GetPoliciesByDriversLiscense endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyRequestDTO policyDTO)
        {
            try
            {
                var insurancePolicy = _mapper.Map<InsurancePolicy>(policyDTO);

                var createdPolicy = await _policyManager.CreateInsurancePolicy(insurancePolicy);
                var createdPolicyDTO = _mapper.Map<PolicyDTO>(createdPolicy);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicyDTO.PolicyId, createdPolicyDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has CreatePolicy endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }

        }
    }
}
