using System.Threading.Tasks;

namespace AllPolicyInsurance.Core
{
    public class MockMessageService : IMessageService
    {
        public Task<string> PublishNewPolicy()
        {
            throw new System.NotImplementedException();
        }
    }
}
