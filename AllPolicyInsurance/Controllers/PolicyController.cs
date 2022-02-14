using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Core;
using AutoMapper;

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
            var policies = await _policyManager.GetPolicies();
            var policyDTO = _mapper.Map<List<PolicyDTO>>(policies);

            return  Ok(policyDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetPoliciesById(int id)
        {
            var policy = await _policyManager.GetPolicyById(id);
            var policyDTO = _mapper.Map<PolicyDTO>(policy);

            if (policyDTO != null)
            {
                return Ok(policyDTO);
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
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyRequest policy)
        {
             var createdPolicy = await _policyManager.CreateInsurancePolicy(policy);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + createdPolicy.PolicyId, createdPolicy);
        }
    }
}
