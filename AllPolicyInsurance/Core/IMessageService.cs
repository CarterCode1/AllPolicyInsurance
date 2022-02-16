using AllPolicyInsurance.Models;
using System.Threading.Tasks;

namespace AllPolicyInsurance.Core
{
    public interface IMessageService
    {
        Task<bool> PublishNewPolicy(InsurancePolicy policy);
    }
}
