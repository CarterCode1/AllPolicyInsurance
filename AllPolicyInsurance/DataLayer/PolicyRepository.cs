using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
 

namespace AllPolicyInsurance.DataLayer
{
    public class PolicyRepository : IPolicyRepository
    {

        private readonly ApplicationDBContext _dbContext;

        public PolicyRepository(ApplicationDBContext ctx)
        {
            _dbContext = ctx;
        }
        public InsurancePolicy CreateInsurancePolicy(PolicyDTO policyDTO)
        {
            var policy = new InsurancePolicy(policyDTO);
  
            _dbContext.InsurancePolicies.Add(policy);
            _dbContext.SaveChanges();

            return policy;
        }

        public void DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public IList<InsurancePolicy> GetPolicies()
        {
            return _dbContext.InsurancePolicies.Include(p => p.Vehicle).
                Include(p => p.Address).
                ToList();
        }

        public IList<InsurancePolicy> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            throw new System.NotImplementedException();
        }

        public InsurancePolicy GetPolicyById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
