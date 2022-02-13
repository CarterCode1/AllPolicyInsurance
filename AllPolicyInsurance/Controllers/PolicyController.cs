using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Models;
using AllPolicyInsurance.DataLayer;
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Core;

namespace AllPolicyInsurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly ILogger<PolicyController> _logger;
        private IPolicyManager _policyManager;

        public PolicyController(ILogger<PolicyController> logger, IPolicyManager policyManager)
        {
            _logger = logger;
            _policyManager = policyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var policies = await _policyManager.GetPolicies();
            return  Ok(policies);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetPoliciesById(int id)
        {
            var policy = await _policyManager.GetPolicyById(id);

            if (policy != null)
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Id: {id} was not found");
        }

        [HttpGet("liscence/{liscence}")]
        public async Task<IActionResult> GetPoliciesByDriversLiscense(string liscence, string sortOrder , bool isExpired = false)
        {
            var policy = await _policyManager.GetPoliciesByDriversLiscense(liscence);

            if(policy.Any())
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Drivers Liscense {liscence} was not found");
        }


        [HttpPost]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyDTO policy)
        {
             var createdPolicy = await _policyManager.CreateInsurancePolicy(policy);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicy.PolicyId, createdPolicy);
        }
    }
}
