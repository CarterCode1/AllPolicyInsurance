using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Models;
using AllPolicyInsurance.DataLayer;
using AllPolicyInsurance.Dto;

namespace AllPolicyInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private IPolicyRepository _policyRepository;

        public PolicyController(ILogger<PolicyController> logger, IPolicyRepository policyRepository)
        {
            _logger = logger;
            _policyRepository = policyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _policyRepository.GetPolicies();
            return  Ok(policies);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetPoliciesById(int id)
        {
            var policy = await _policyRepository.GetPolicyById(id);

            if (policy != null)
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Id: {id} was not found");
        }

        [HttpGet("liscence/{liscence}")]
        public async Task<IActionResult> GetPoliciesByDriversLiscense(string liscence, string sortOrder , bool isExpired = false)
        {
            var policy = await _policyRepository.GetPoliciesByDriversLiscense(liscence);

            if(policy.Any())
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Drivers Liscense {liscence} was not found");
        }


        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyDTO policy)
        {
             var createdPolicy = await _policyRepository.CreateInsurancePolicy(policy);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicy.Id, createdPolicy);
        }
    }
}
