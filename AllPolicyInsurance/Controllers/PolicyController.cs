using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Models;
using AllPolicyInsurance.DataLayer;

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
        public IActionResult GetPolicies()
        {
            return Ok(_policyRepository.GetPolicies());
        }

        [HttpGet("id/{id}")]
        public IActionResult GetPoliciesById(int id)
        {
            var policy = _policyRepository.GetPolicyById(id);

            if (policy != null)
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Id: {id} was not found");
        }

        [HttpGet("liscence/{liscence}")]
        public IActionResult GetPoliciesByDriversLiscense(string liscence, string sortOrder , bool isExpired = false)
        {
            var policy = _policyRepository.GetPoliciesByDriversLiscense(liscence);

            if(policy.Any())
            {
                return Ok(policy);
            }
            return NotFound($"Policy with Drivers Liscense {liscence} was not found");
        }


        [HttpPost]
        public IActionResult CreatePolicy([FromBody] InsurancePolicy insurancePolicy)
        {
            _policyRepository.CreateInsurancePolicy(insurancePolicy);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + insurancePolicy.Id, insurancePolicy);
        }
    }
}
