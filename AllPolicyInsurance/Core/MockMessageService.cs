using AllPolicyInsurance.Models;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using System;

namespace AllPolicyInsurance.Core
{
    public class MockMessageService : IMessageService
    {
        public bool PublishNewPolicy(InsurancePolicy policy)
        {
            bool result = false;

            Policy.Handle<Exception>()
                .Retry(3, (exception, retryCount) =>
                {
                    Task.Delay(500).Wait();
                })
            .Execute(() =>
            {
                var rand = new Random();
                result = (bool)(rand.Next(0, 1) == 0);
            });

            return result;
        }
    }
}
