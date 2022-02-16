using AllPolicyInsurance.Models;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using System;

namespace AllPolicyInsurance.Core
{
    public class MockMessageService : IMessageService
    {
        private AsyncRetryPolicy _retryPolicy;

        public MockMessageService()
        {
            _retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(3, retryAttempt =>
            {
                var timeToWait = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                Console.WriteLine($"Waiting {timeToWait.TotalSeconds} seconds");

                return timeToWait;
            }
    );
        }

        public Task<bool> PublishNewPolicy(InsurancePolicy policy)
        {
            var rand = new Random();
            
            return Task.FromResult<bool>(rand.Next(2) == 0);

        }
    }
}
