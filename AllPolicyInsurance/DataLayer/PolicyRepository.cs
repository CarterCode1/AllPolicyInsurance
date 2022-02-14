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
            return await  _dbContext.InsurancePolicies
                    .Include(x => x.Vehicles)
                    .Include(y => y.Address)
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
