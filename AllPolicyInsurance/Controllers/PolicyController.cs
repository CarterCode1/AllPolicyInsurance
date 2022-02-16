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
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private readonly IConfiguration _configuration;
        private IPolicyManager _policyManager;
        private readonly IMapper _mapper;

        public PolicyController(ILogger<PolicyController> logger, IConfiguration configuration, IMapper mapper, IPolicyManager policyManager)
        {

            _logger = logger;
            _configuration = configuration;
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
        public async Task<IActionResult> GetPoliciesByDriversLiscense(string liscence, string sortOrder, bool isExpired = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(liscence))
                {
                    return BadRequest("Drivers Liscence number is required.");
                }

                if (!int.TryParse(liscence, out _))
                {
                    return BadRequest("Drivers Liscence is required to in number format.");
                }

                var policies = await _policyManager.GetPoliciesByDriversLiscense(liscence, sortOrder, isExpired);
                var policyDTO = _mapper.Map<List<PolicyDTO>>(policies);

                if (policyDTO.Any())
                {
                    return Ok(policyDTO);
                }
                return NotFound($"Policy with Drivers Liscense {liscence} was not found.");
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

                if (policyRequestDTO.EffectiveDate < DateTime.Now.AddDays(30))
                {
                    return BadRequest("Effective Date must be 30 days in the future.");
                }

                foreach (VehicleDTO vehicle in policyRequestDTO.Vehicles)
                {
                    if (int.Parse(vehicle.Year) > int.Parse(_configuration["ClassicVehicle"]))
                    {
                        return BadRequest($"Vehicle {vehicle.Make} {vehicle.Model} is ineligible for coverage due to it not meeting the requirements of a Classic Vehicle.");
                    }
                }


                var responseTuple = await _policyManager.CreateInsurancePolicy(_mapper.Map<InsurancePolicy>(policyRequestDTO));

                if (responseTuple.Item1 == true)
                {
                    var createdPolicyDTO = _mapper.Map<PolicyDTO>(responseTuple.Item2);

                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicyDTO.PolicyId, createdPolicyDTO);
                }

                return BadRequest(responseTuple.Item3);


            }
            catch (Exception ex)
            {
                _logger.LogError("An exception has occurred in CreatePolicy endpoint, error details: {@Exception}", ex);
                return StatusCode(500);
            }

        }
    }
}
