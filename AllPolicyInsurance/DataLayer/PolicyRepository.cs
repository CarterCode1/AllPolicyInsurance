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
        public async Task<InsurancePolicy> CreateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
  
            _dbContext.InsurancePolicies.Add(insurancePolicy);
            await _dbContext.SaveChangesAsync();

            return insurancePolicy;
        }

        public Task DeletePolicy(InsurancePolicy policy)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<InsurancePolicy>> GetPolicies()
        {
             var policies = await  _dbContext.InsurancePolicies
                    .Include(x => x.Vehicles)
                    .Include(y => y.Address)
                    .ToListAsync();

            return policies;
        }

        public async Task<IList<InsurancePolicy>> GetPoliciesByDriversLiscense(string liscenseNumber)
        {
            var policies = await _dbContext.InsurancePolicies
                .Include(x => x.Vehicles)
                .Include(y => y.Address)
                .Where(p=>p.DriversLicenseNumber == liscenseNumber)
                .ToListAsync();

            return policies;
        }

        public async Task<InsurancePolicy> GetPolicyById(int id)
        {
           var policy =  await _dbContext.InsurancePolicies
                .Include(x => x.Vehicles)
                .Include(y => y.Address)
                .FirstOrDefaultAsync(p => p.PolicyId == id);

            return policy;
        }
    }
}
