using System.Threading.Tasks;

namespace AllPolicyInsurance.Core
{
    public interface IMessageService
    {
        Task<string> PublishNewPolicy();
    }
}
