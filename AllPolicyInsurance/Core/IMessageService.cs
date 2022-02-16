using AllPolicyInsurance.Models;
using System.Threading.Tasks;

namespace AllPolicyInsurance.Core
{
    public interface IMessageService
    {
        bool PublishNewPolicy(InsurancePolicy policy);
    }
}
