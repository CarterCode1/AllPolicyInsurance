using Microsoft.EntityFrameworkCore;

namespace AllPolicyInsurance.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :
            base(options)
        {

        }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
