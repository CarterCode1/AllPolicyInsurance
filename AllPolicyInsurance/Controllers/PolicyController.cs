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

        [HttpGet("byId")]
        public IActionResult GetPoliciesById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("byLiscence")]
        public IActionResult GetPoliciesByDriversLiscense(string liscence)
        {
            return Ok(_policyRepository.GetPoliciesByDriversLiscense(liscence));
        }


        [HttpPost]
        public IActionResult CreatePolicy([FromBody] InsurancePolicy insurancePolicy)
        {
            throw new NotImplementedException();
        }
    }
}
