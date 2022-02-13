using AllPolicyInsurance.Dto;
using AllPolicyInsurance.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AllPolicyInsurance.DataLayer
{
    public class PolicyRepository : IPolicyRepository
    {

        private readonly ApplicationDBContext _dbContext;

        public PolicyRepository(ApplicationDBContext ctx)
        {
            _dbContext = ctx;
        }
        public async Task<InsurancePolicy> CreateInsurancePolicy(PolicyDTO policyDTO)
        {
            var policy = new InsurancePolicy(policyDTO);
  
            _dbContext.InsurancePolicies.Add(policy);
            await _dbContext.SaveChangesAsync();

            return policy;
        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<InsurancePolicy>> GetPolicies()
        {
            return await _dbContext.InsurancePolicies.Include(p => p.Vehicles).
                Include(p => p.Address)
                .ToListAsync();
        }

        public async Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            return await _dbContext.InsurancePolicies
                .Include(x => x.Vehicles)
                .Include(y => y.Address)
                .Where(p=>p.DriversLicenseNumber == liscenseNumber)
                .ToListAsync();
        }

        public async Task<InsurancePolicy> GetPolicyById(int id)
        {
            return await _dbContext.InsurancePolicies
                .Include(x => x.Vehicles)
                .Include(y => y.Address)
                .FirstOrDefaultAsync(p => p.PolicyId == id);
        }
    }
}
